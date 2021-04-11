import { IndividualCustomerService } from './../../services/individual-customer.service';
import { IndividualCustomer } from './../../models/individualCustomer';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-individual-customer',
  templateUrl: './individual-customer.component.html',
  styleUrls: ['./individual-customer.component.css']
})
export class IndividualCustomerComponent implements OnInit {

  individualCustomers:IndividualCustomer[]=[];
  constructor(private individualCustomerService:IndividualCustomerService) { }

  ngOnInit(): void {
    this.getIndividualCustomers();
  }

  getIndividualCustomers(){
    this.individualCustomerService.getIndividualCustomers().subscribe(response =>{
      this.individualCustomers = response.data;
    })
  }
}
