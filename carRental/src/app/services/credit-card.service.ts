import { CreditCard } from './../models/creditCard';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ListResponseModel } from '../models/responseModels/listResponseModel';
import { ObjectResponseModel } from '../models/responseModels/objectResponseModel';
import { ResponseModel } from '../models/responseModels/responseModel';

@Injectable({
  providedIn: 'root'
})
export class CreditCardService {

  apiUrl = environment.api_url + "creditCards/"
  constructor(private httpClient:HttpClient) { }

  getCreditCards(customerId:number):Observable<ListResponseModel<CreditCard>>{
    let newPath = this.apiUrl + "getbycustomerid?customerid=" +customerId;
    return this.httpClient.get<ListResponseModel<CreditCard>>(newPath);
  }

  add(creditCard:CreditCard):Observable<ResponseModel>{
    return this.httpClient.post<ResponseModel>(this.apiUrl+ "add", creditCard);
  }

  delete(creditCard:CreditCard):Observable<ResponseModel>{
    return this.httpClient.post<ResponseModel>(this.apiUrl+ "delete", creditCard);
  }
}
