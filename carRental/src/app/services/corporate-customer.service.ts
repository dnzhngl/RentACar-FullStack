import { environment } from './../../environments/environment';
import { AuthService } from 'src/app/services/auth.service';
import { ListResponseModel } from './../models/responseModels/listResponseModel';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CorporateCustomer } from '../models/corporateCustomer';
import { ObjectResponseModel } from '../models/responseModels/objectResponseModel';

@Injectable({
  providedIn: 'root'
})
export class CorporateCustomerService {

  apiUrl = environment.api_url + 'corporateCustomers/';
  
  constructor(private httpClient:HttpClient, private authService:AuthService) { }

  getCorporatecustomers():Observable<ListResponseModel<CorporateCustomer>>{
    let newPath = this.apiUrl + "getall";
    return this.httpClient.get<ListResponseModel<CorporateCustomer>>(newPath);
  }

  getCurrentCustomer():Observable<ObjectResponseModel<CorporateCustomer>>{
    let currentUserEmail = this.authService.userEmail;
    let newPath = this.apiUrl + "getbyemail?email=" + currentUserEmail;
    return this.httpClient.get<ObjectResponseModel<CorporateCustomer>>(newPath);
  }
}
