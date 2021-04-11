import { CorporateCustomerService } from './../../services/corporate-customer.service';
import { CorporateCustomer } from './../../models/corporateCustomer';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-corporate-customer',
  templateUrl: './corporate-customer.component.html',
  styleUrls: ['./corporate-customer.component.css']
})
export class CorporateCustomerComponent implements OnInit {

  corporateCustomers:CorporateCustomer[]=[];
  constructor(private corporateCustomerService:CorporateCustomerService) { }

  ngOnInit(): void {
    this.getCorporateCustomers();
  }

  getCorporateCustomers(){
    this.corporateCustomerService.getCorporatecustomers().subscribe(result =>{
      this.corporateCustomers = result.data;
    })
  }
}
