import { CarImageDto } from './../models/carImageDto';
import { ResponseModel } from './../models/responseModels/responseModel';
import { ObjectResponseModel } from './../models/responseModels/objectResponseModel';
import { CarImage } from './../models/carImage';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ListResponseModel } from '../models/responseModels/listResponseModel';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})
export class CarImageService {

  rootUrl="https://localhost:44315/";
  apiUrl = environment.api_url + 'carImages/';
  defaultImage:string;

  constructor(private httpClient:HttpClient) {
    this.defaultImage = this.getDefaultImage();
   }

  getDefaultImage():string{
    let defaultImagePath = this.rootUrl + "Uploads/Images/defaultImage.png";
    this.defaultImage = defaultImagePath;
    return defaultImagePath;
  }

  getImagesByCarId(carId:number):Observable<ListResponseModel<CarImage>>{
    let newPath = this.apiUrl + "getAllByCar?carId=" + carId;
    return this.httpClient.get<ListResponseModel<CarImage>>(newPath);
  }

  delete(carImages:CarImage[]){
    let newPath = this.apiUrl + "deleteImages";
    return this.httpClient.post<ResponseModel>(newPath, carImages)
  }

  add(carImages:CarImageDto[]){
    let newPath = this.apiUrl + "deleteImages";
    return this.httpClient.post<ResponseModel>(newPath, carImages)
  }
}
