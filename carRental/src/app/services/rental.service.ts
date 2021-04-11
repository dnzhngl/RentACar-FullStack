import { ObjectResponseModel } from './../models/responseModels/objectResponseModel';
import { Rental } from 'src/app/models/rental';
import { ListResponseModel } from './../models/responseModels/listResponseModel';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { RentalDetailDto } from '../models/rentalDetailDto';
import { ResponseModel } from '../models/responseModels/responseModel';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class RentalService {

  apiUrl = environment.api_url + "rentals/"
  // apiUrl="https://localhost:44315/api/";
  constructor(private httpClient:HttpClient) { }

  getRentals():Observable<ListResponseModel<RentalDetailDto>>{
    let newPath = this.apiUrl + "GetAllRentalsDetails";
    return this.httpClient.get<ListResponseModel<RentalDetailDto>>(newPath);
  }

  getRentalDetail(rentalId:number):Observable<ObjectResponseModel<RentalDetailDto>>{
    return this.httpClient.get<ObjectResponseModel<RentalDetailDto>>(this.apiUrl+ "GetRentalDetails?rentalId="+ rentalId);
  }

  add(rental:RentalDetailDto):Observable<ResponseModel>{
    return this.httpClient.post<ResponseModel>(this.apiUrl+ "add", rental);
  }

  update(rental:RentalDetailDto):Observable<ObjectResponseModel<RentalDetailDto>>{
    return this.httpClient.post<ObjectResponseModel<RentalDetailDto>>(this.apiUrl+ "update", rental);
  }

  delete(rental:RentalDetailDto):Observable<ResponseModel>{
    return this.httpClient.post<ResponseModel>(this.apiUrl+ "delete", rental);
  }
}
