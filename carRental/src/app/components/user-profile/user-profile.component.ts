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
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {

  individualCustomer:IndividualCustomer;
  corporateCustomer:CorporateCustomer;
  currentCustomer:Customer;
  userName:string;
  customerType:string;
  image:string;

  constructor(
    private authService:AuthService,
    private activatedRoute:ActivatedRoute,
    private individualCustomerService:IndividualCustomerService,
    private corporateCustomerService:CorporateCustomerService,
    private localStorageService:LocalStorageService,
    private imageService:CarImageService
  ) { }

  ngOnInit(): void {
  this.userName = this.authService.userName; 
  this.customerType = this.localStorageService.getTypeOfCustomer(); 
  this.image = this.imageService.defaultImage;
  this.activatedRoute.params.subscribe(params => {
    if(params['individualCustomer']){
      this.getIndividualCustomer();
    }
    else if(params['corporateCustomer']){
      this.getCorporateCustomer();
    }

  })
  }


  getIndividualCustomer(){
    this.individualCustomerService.getCurrentCustomer().subscribe(response=>{
      this.individualCustomer = response.data;
      this.currentCustomer = response.data;
    })
  }

  getCorporateCustomer(){
    this.corporateCustomerService.getCurrentCustomer().subscribe(response=>{
      this.corporateCustomer = response.data;
      this.currentCustomer = response.data;
      console.log("corporate customer",this.corporateCustomer);
      console.log("currentCustomer",this.currentCustomer);

    })
  }

}
