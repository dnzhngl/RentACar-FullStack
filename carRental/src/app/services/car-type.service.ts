import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ListResponseModel } from '../models/responseModels/listResponseModel';
import { CarType } from '../models/carType';
import { ResponseModel } from '../models/responseModels/responseModel';
import { environment } from 'src/environments/environment';
import { ObjectResponseModel } from '../models/responseModels/objectResponseModel';

@Injectable({
  providedIn: 'root'
})
export class CarTypeService {

  apiUrl = environment.api_url + 'carTypes/';

  constructor(private httpClient:HttpClient) { }

  getCarTypes():Observable<ListResponseModel<CarType>>{
    let newPath = this.apiUrl + "getall"
    return this.httpClient.get<ListResponseModel<CarType>>(newPath);
  }
  
  getById(carTypeId:number):Observable<ObjectResponseModel<CarType>>{
    let newPath = this.apiUrl + "getbyid?id=" + carTypeId;
    return this.httpClient.get<ObjectResponseModel<CarType>>(newPath);
  }


  add(carType:CarType):Observable<ResponseModel>{
    let newPath = this.apiUrl + "add";
    return this.httpClient.post<ResponseModel>(newPath, carType);
  }

  delete(carType:CarType):Observable<ResponseModel>{
    let newPath = this.apiUrl + "delete";
    return this.httpClient.post<ResponseModel>(newPath, carType);
  }
  
  update(carType:CarType):Observable<ResponseModel>{
    let newPath = this.apiUrl + "update";
    return this.httpClient.post<ResponseModel>(newPath, carType);
  }
}
