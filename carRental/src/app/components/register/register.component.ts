import { Customer } from './../../models/customer';
import { CorporateCustomer } from './../../models/corporateCustomer';
import { IndividualCustomer } from './../../models/individualCustomer';
import { RegisterModel } from './../../models/registerModel';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  registerForm:FormGroup;
  customerType:string="";
  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService,
    private toastrService: ToastrService,
    private router:Router,
  ) { }

  ngOnInit(): void {
    this.customerType = localStorage.getItem("CustomerType");
    this.createRegisterForm();
  }

  createRegisterForm() {
    this.registerForm = this.formBuilder.group({
      userName:['', Validators.required],
      email: ['', Validators.required],
      password: ['', Validators.required],
    });
  }
  register() {
    if (this.registerForm.valid) {
      let registerModel: RegisterModel = Object.assign({}, this.registerForm.value);
      this.authService.register(registerModel, this.customerType);
      this.setTypeOfCustomer();
      }else {
      this.toastrService.warning("Please fill in all fields.", "Attention")
    }
  }

  setTypeOfCustomer(){
    let customer="";
    if(this.router.url === "/register/corporate"){
      customer = "corporate"
    } else if( this.router.url ==="/register/individual"){
      customer = "individual"
    }
    localStorage.setItem("CustomerType", customer);
  }


}
