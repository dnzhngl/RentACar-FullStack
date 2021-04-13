import { ToastrService } from 'ngx-toastr';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PasswordChangeDto } from './../../models/passwordChangeDto';
import { User } from './../../models/user';
import { UserService } from './../../services/user.service';
import { CarImageService } from './../../services/car-image.service';
import { LocalStorageService } from './../../services/local-storage.service';
import { Customer } from './../../models/customer';
import { CorporateCustomer } from './../../models/corporateCustomer';
import { IndividualCustomer } from './../../models/individualCustomer';
import { ActivatedRoute } from '@angular/router';
import { IndividualCustomerService } from './../../services/individual-customer.service';
import { CustomerService } from './../../services/customer.service';
import { AuthService } from 'src/app/services/auth.service';
import { Component, OnInit } from '@angular/core';
import { CorporateCustomerService } from 'src/app/services/corporate-customer.service';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css'],
})
export class UserProfileComponent implements OnInit {
  user: User;
  individualCustomer: IndividualCustomer;
  corporateCustomer: CorporateCustomer;
  currentCustomer: Customer;
  userName: string;
  customerType: string;
  image: string;

  passwordSection: boolean = false;
  passwordChangeForm: FormGroup;
  // newPassword: String = '';
  // confirmPassword: String = '';

  constructor(
    private authService: AuthService,
    private activatedRoute: ActivatedRoute,
    private userService: UserService,
    private toastrService: ToastrService,
    private individualCustomerService: IndividualCustomerService,
    private corporateCustomerService: CorporateCustomerService,
    private localStorageService: LocalStorageService,
    private imageService: CarImageService,
    private formBuilder: FormBuilder
  ) {}

  ngOnInit(): void {
    this.userName = this.authService.userName;
    this.customerType = this.localStorageService.getTypeOfCustomer();
    this.image = this.imageService.defaultImage;

    this.getCurrentUser();
    this.activatedRoute.params.subscribe((params) => {
      if (params['individualCustomer']) {
        this.getIndividualCustomer();
      } else if (params['corporateCustomer']) {
        this.getCorporateCustomer();
      }
    });
  }

  getCurrentUser() {
    this.userService.getCurrentUser().subscribe((response) => {
      this.user = response.data;
    });
  }

  getIndividualCustomer() {
    this.individualCustomerService
      .getCurrentCustomer()
      .subscribe((response) => {
        this.individualCustomer = response.data;
        this.currentCustomer = response.data;
      });
  }

  getCorporateCustomer() {
    this.corporateCustomerService.getCurrentCustomer().subscribe((response) => {
      this.corporateCustomer = response.data;
      this.currentCustomer = response.data;
      console.log('corporate customer', this.corporateCustomer);
      console.log('currentCustomer', this.currentCustomer);
    });
  }

  openPasswordSection() {
    this.passwordSection = !this.passwordSection;
    this.createPasswordChangeForm();
  }

  createPasswordChangeForm() {
    this.passwordChangeForm = this.formBuilder.group({
      Id: [this.authService.userId],
      newPassword: ['', Validators.required],
      confirmPassword: ['', Validators.required],
    });
  }

  changePassword() {
    if (this.passwordChangeForm.valid) {
      if (this.passwordChangeForm.controls['newPassword'].value === this.passwordChangeForm.controls['confirmPassword'].value) {
        let passwordChangeModel:PasswordChangeDto = Object.assign({}, this.passwordChangeForm.value);
        this.userService.changePassword(passwordChangeModel).subscribe(response => {
          this.toastrService.success(response.message);
        }, errorResponse => {
          this.toastrService.error(errorResponse.error.Message);
        });
      }else{
        this.toastrService.warning("Password confirmation is not valid.", "Attention")
      }
    }else{
        this.toastrService.warning("Please fill in all fields.", "Attention")
      }
  }
}
