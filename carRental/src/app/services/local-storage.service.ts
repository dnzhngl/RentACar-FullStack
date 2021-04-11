import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LocalStorageService {

  tokenKey:string = "token";

  constructor() { }

  setToken(token:string){
    localStorage.setItem(this.tokenKey, token)
  }

  getToken():string{
    return localStorage.getItem(this.tokenKey);
  } 
  
  removeToken(){
    localStorage.removeItem(this.tokenKey);
  }

  removeItem(itemName:string){
    localStorage.removeItem(itemName);
  }

  setItem(key:string, value:string){
    localStorage.setItem(key, value);
  }

  getTypeOfCustomer(){
    return localStorage.getItem("CustomerType");
  }
}
