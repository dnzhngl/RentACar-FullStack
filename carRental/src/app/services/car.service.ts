import { environment } from './../../environments/environment';
import { ObjectResponseModel } from './../models/responseModels/objectResponseModel';
import { CarDetailDto } from './../models/carDetailDto';
import { Car } from './../models/car';
import { Observable } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ListResponseModel } from '../models/responseModels/listResponseModel';
import { ResponseModel } from '../models/responseModels/responseModel';

@Injectable({
  providedIn: 'root'
})
export class CarService {

  apiUrl = environment.api_url + "cars/";
  constructor(private httpClient:HttpClient) { }

  getCarDetail(carId:number){
    let newPath = this.apiUrl + "getbyid?id="+carId;
    return this.httpClient.get<ObjectResponseModel<CarDetailDto>>(newPath);
  }

  getCarsDetailDto():Observable<ListResponseModel<CarDetailDto>>{
    let newPath = this.apiUrl + "getallcarsdetails"
    return this.httpClient.get<ListResponseModel<CarDetailDto>>(newPath);
  }

  getCarsWithImages():Observable<ListResponseModel<CarDetailDto>>{
    let newPath = this.apiUrl + "GetCarsDetailsWithImages";
    return this.httpClient.get<ListResponseModel<CarDetailDto>>(newPath);
  }

  getCarsAvailableBetweenDates(rentDate:Date, returnDate:Date = null):Observable<ListResponseModel<CarDetailDto>>{
    let newPath = this.apiUrl + `GetCarsAvailable?rentDate=${rentDate}`;
    if(returnDate != null){
      newPath += `&returnDate=${returnDate}`;
    }
    return this.httpClient.get<ListResponseModel<CarDetailDto>>(newPath);
  }

  add(car:CarDetailDto):Observable<ResponseModel>{
    let newPath = this.apiUrl + "add";
    return this.httpClient.post<ResponseModel>(newPath, car);
  }

  delete(car:CarDetailDto):Observable<ResponseModel>{
    let newPath = this.apiUrl + "delete";
    return this.httpClient.post<ResponseModel>(newPath, car);
  }
  
  update(car:CarDetailDto):Observable<ResponseModel>{
    let newPath = this.apiUrl + "update";
    console.log("service",car)
    return this.httpClient.post<ResponseModel>(newPath, car);
  }

//#region Filtered by one property
  getCarsByBrand(brandId:number):Observable<ListResponseModel<CarDetailDto>>{
    let newPath = this.apiUrl + "GetAllCarsDetailByBrand?brandId=" + brandId;
    return this.httpClient.get<ListResponseModel<CarDetailDto>>(newPath);
  }

  getCarsByColor(colorId:number):Observable<ListResponseModel<CarDetailDto>>{
    let newPath = this.apiUrl + "GetAllCarsDetailByColor?colorId=" + colorId;
    return this.httpClient.get<ListResponseModel<CarDetailDto>>(newPath);
  }

  getCarsByCarType(carTypeId:number):Observable<ListResponseModel<CarDetailDto>>{
    let newPath = this.apiUrl + "GetAllCarsDetailByCarType?carTypeId=" + carTypeId;
    return this.httpClient.get<ListResponseModel<CarDetailDto>>(newPath);
  }
  //#endregion
}
