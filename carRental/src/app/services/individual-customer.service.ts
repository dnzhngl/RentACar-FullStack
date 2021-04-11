import { AuthService } from './auth.service';
import { IndividualCustomer } from './../models/individualCustomer';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ListResponseModel } from '../models/responseModels/listResponseModel';
import { environment } from 'src/environments/environment';
import { ObjectResponseModel } from '../models/responseModels/objectResponseModel';

@Injectable({
  providedIn: 'root'
})
export class IndividualCustomerService {

  apiUrl = environment.api_url + 'individualCustomers/'

  constructor(private httpClient:HttpClient, private authService:AuthService) { }

  getIndividualCustomers():Observable<ListResponseModel<IndividualCustomer>>{
    let newPath = this.apiUrl + "getall";
    return this.httpClient.get<ListResponseModel<IndividualCustomer>>(newPath);
  }

  getCurrentCustomer():Observable<ObjectResponseModel<IndividualCustomer>>{
    let currentUserEmail = this.authService.userEmail;
    let newPath = this.apiUrl + "getbyemail?email=" + currentUserEmail;
    return this.httpClient.get<ObjectResponseModel<IndividualCustomer>>(newPath);
  }
}
