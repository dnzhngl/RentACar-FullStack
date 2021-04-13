import { User } from './../models/user';
import { Router } from '@angular/router';
import { LocalStorageService } from './local-storage.service';
import { ObjectResponseModel } from './../models/responseModels/objectResponseModel';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { LoginModel } from '../models/loginModel';
import { TokenModel } from '../models/tokenModel';
import { RegisterModel } from '../models/registerModel';
import { ToastrService } from 'ngx-toastr';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  apiUrl = environment.api_url + 'auth/';
  jwtHelper: JwtHelperService = new JwtHelperService();
  
  userId:number;
  decodedToken:any;
  userName:string;
  userEmail:string;
  claims:any;

  constructor(
    private httpClient: HttpClient,
    private storageService: LocalStorageService,
    private router: Router,
    private toastrService: ToastrService
  ) {
    this.setClaims();    
  }

  login(user: LoginModel, routingPage:string) {
    let newPath = this.apiUrl + 'login';
    return this.httpClient
      .post<ObjectResponseModel<TokenModel>>(newPath, user)
      .subscribe((response) => {
        this.storageService.setToken(response.data.token);
        var decodedToken = this.jwtHelper.decodeToken(this.storageService.getToken());
        this.userName = String(this.tokenValues(decodedToken, '/name'));
        this.router.navigateByUrl(`/${routingPage}`);
      }, responseError => {
        this.toastrService.error(responseError.error);
      });
  }

  register(user: RegisterModel, customerType:string) {
    let newPath = this.apiUrl + 'register';
    return this.httpClient.post<ObjectResponseModel<TokenModel>>(newPath, user).subscribe(response=>{
      this.router.navigateByUrl(`/login/${customerType}`)
    });
  }


  logOut() {
    this.storageService.removeToken();
    this.claims = [];
    this.storageService.removeItem('CustomerType');
  }

  isAuthenticated() {
    if (this.storageService.getToken()) {
      let isExpired = this.jwtHelper.isTokenExpired(
        this.storageService.getToken()
      );
      return !isExpired;
    } else {
      return false;
    }
  }


  setClaims(){
    if(this.storageService.getToken() != null){
    this.decodedToken = this.jwtHelper.decodeToken(this.storageService.getToken());
    this.userName = String(this.tokenValues(this.decodedToken, "/name"));
    this.userEmail = String(this.tokenValues(this.decodedToken, 'email'))
    this.userId = Number(this.tokenValues(this.decodedToken, '/nameidentifier'));
    this.claims = this.tokenValues(this.decodedToken, "/role")
    }
  }

  // returns given prop values in the given token, if not found returns undefined
  // fields : email, exp, /role, /name, /nameidentifier
  tokenValues(decodedToken: any, propName: string) {
    let index:number = Object.keys(decodedToken).findIndex(x => x.endsWith(propName));
    return Object.values(decodedToken)[index];
  }
}
