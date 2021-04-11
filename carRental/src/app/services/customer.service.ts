import { AuthService } from './auth.service';
import { environment } from './../../environments/environment';
import { ListResponseModel } from './../models/responseModels/listResponseModel';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Customer } from '../models/customer';
import { ObjectResponseModel } from '../models/responseModels/objectResponseModel';
import { ResponseModel } from '../models/responseModels/responseModel';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  apiUrl = environment.api_url + 'customers/';
  // apiUrl = "https://localhost:44315/api/";
  constructor(private httpClient:HttpClient, private authService:AuthService) { }

  getCustomers():Observable<ListResponseModel<Customer>>{
    let newPath = this.apiUrl + "getall";
    return this.httpClient.get<ListResponseModel<Customer>>(newPath);
  }

  getCurrentCustomer():Observable<ObjectResponseModel<Customer>>{
    let currentUserEmail = this.authService.userEmail;
    let newPath = this.apiUrl + "getbyemail?email=" + currentUserEmail;
    return this.httpClient.get<ObjectResponseModel<Customer>>(newPath);
  }
  add(customer:Customer):Observable<ResponseModel>{
    let newPath = this.apiUrl + "add";
    return this.httpClient.post<ResponseModel>(newPath, customer);
  }

  delete(customer:Customer):Observable<ResponseModel>{
    let newPath = this.apiUrl + "delete";
    return this.httpClient.post<ResponseModel>(newPath, customer);
  }
  
  update(customer:Customer):Observable<ResponseModel>{
    let newPath = this.apiUrl + "update";
    return this.httpClient.post<ResponseModel>(newPath, customer);
  }
}
