import { ListResponseModel } from './../models/responseModels/listResponseModel';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Color } from '../models/color';
import { ResponseModel } from '../models/responseModels/responseModel';
import { environment } from 'src/environments/environment';
import { ObjectResponseModel } from '../models/responseModels/objectResponseModel';

@Injectable({
  providedIn: 'root'
})
export class ColorService {

  apiUrl = environment.api_url + 'colors/';

  constructor(private httpClient:HttpClient) { }

  getColors():Observable<ListResponseModel<Color>>{
    let newPath = this.apiUrl + "getall"
    return this.httpClient.get<ListResponseModel<Color>>(newPath);
  }

  getById(colorId:number):Observable<ObjectResponseModel<Color>>{
    let newPath = this.apiUrl + "getbyid?id=" + colorId;
    return this.httpClient.get<ObjectResponseModel<Color>>(newPath);
  }

  add(color:Color):Observable<ResponseModel>{
    let newPath = this.apiUrl + "add";
    return this.httpClient.post<ResponseModel>(newPath, color);
  }

  delete(color:Color):Observable<ResponseModel>{
    let newPath = this.apiUrl + "delete";
    return this.httpClient.post<ResponseModel>(newPath, color);
  }
  
  update(color:Color):Observable<ResponseModel>{
    let newPath = this.apiUrl + "update";
    return this.httpClient.post<ResponseModel>(newPath, color);
  }
}
