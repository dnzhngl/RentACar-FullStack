import { ToastrService } from 'ngx-toastr';
import { CustomerService } from './../../../services/customer.service';
import { Component, OnInit } from '@angular/core';
import { Customer } from 'src/app/models/customer';
import { ListResponseModel } from 'src/app/models/responseModels/listResponseModel';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.css']
})
export class CustomerListComponent implements OnInit {

  response = {} as ListResponseModel<Customer>;
  customers:Customer[]=[];
  constructor(
    private customerService:CustomerService,
    private toastrService:ToastrService
  ) { }

  ngOnInit(): void {
    this.getCustomers();
  }
  getCustomers(){
    this.customerService.getCustomers().subscribe(response=>{
      this.customers = response.data;
    }, errorResponse => {
      this.response.message = errorResponse.error.message; 
    })
  }

  delete(customer:Customer){
    this.customerService.delete(customer).subscribe(response => {
      this.toastrService.success(response.message);
      this.getCustomers();
    }, errorResponse =>{
      this.toastrService.error(errorResponse.error);
    })
  }

  update(customer:Customer){
    this.customerService.update(customer).subscribe(response => {
      this.toastrService.success(response.message);
      this.getCustomers();
    }, errorResponse =>{
      this.toastrService.error(errorResponse.error);
    })
  }
}
