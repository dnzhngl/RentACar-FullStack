import { ListResponseModel } from './../models/responseModels/listResponseModel';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Brand } from '../models/brand';
import { ResponseModel } from '../models/responseModels/responseModel';
import { environment } from 'src/environments/environment';
import { ObjectResponseModel } from '../models/responseModels/objectResponseModel';

@Injectable({
  providedIn: 'root'
})
export class BrandService {

  apiUrl = environment.api_url + 'brands/';

  constructor(private httpClient:HttpClient) { }

  getBrands():Observable<ListResponseModel<Brand>>{
    let newPath = this.apiUrl + "getall"
    return this.httpClient.get<ListResponseModel<Brand>>(newPath);
  }

  getById(brandId:number):Observable<ObjectResponseModel<Brand>>{
    let newPath = this.apiUrl + "getbyid?id=" + brandId;
    return this.httpClient.get<ObjectResponseModel<Brand>>(newPath);
  }

  add(brand:Brand):Observable<ResponseModel>{
    let newPath = this.apiUrl + "add";
    return this.httpClient.post<ResponseModel>(newPath, brand);
  }

  delete(brand:Brand):Observable<ResponseModel>{
    let newPath = this.apiUrl + "delete";
    return this.httpClient.post<ResponseModel>(newPath, brand);
  }
  
  update(brand:Brand):Observable<ResponseModel>{
    let newPath = this.apiUrl + "update";
    return this.httpClient.post<ResponseModel>(newPath, brand);
  }
  
}
