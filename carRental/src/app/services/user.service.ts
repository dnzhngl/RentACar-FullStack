import { PasswordChangeDto } from './../models/passwordChangeDto';
import { User } from './../models/user';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ObjectResponseModel } from '../models/responseModels/objectResponseModel';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  apiUrl = environment.api_url + 'users/'

  constructor(private httpClient:HttpClient, private authService:AuthService) { }

  getCurrentUser():Observable<ObjectResponseModel<User>>{
    let currentUserId = this.authService.userId;
    let newPath = this.apiUrl + "getbyid?id=" + currentUserId;
    return this.httpClient.get<ObjectResponseModel<User>>(newPath);
  }

  changePassword(passwordChange:PasswordChangeDto):Observable<ObjectResponseModel<PasswordChangeDto>>{
    let newPath = this.apiUrl + "passwordChange";
    return this.httpClient.post<ObjectResponseModel<PasswordChangeDto>>(newPath,passwordChange);
  }
}
