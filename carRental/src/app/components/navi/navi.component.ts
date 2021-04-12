import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { Component, OnInit } from '@angular/core';
import { LocalStorageService } from 'src/app/services/local-storage.service';

@Component({
  selector: 'app-navi',
  templateUrl: './navi.component.html',
  styleUrls: ['./navi.component.css']
})
export class NaviComponent implements OnInit {

  isLoggedIn:Boolean;
  userName:string;
  typeOfCustomer:string;

  constructor(
    private authService:AuthService,
    private router:Router,
    private storageService:LocalStorageService

    ) { }

  ngOnInit(): void {
    this.isLoggedIn = this.authService.isAuthenticated();
    this.getTypeOfCustomer();
    this.userName = this.authService.userName;
  }

  getTypeOfCustomer(){
    this.typeOfCustomer = this.storageService.getTypeOfCustomer();
  }

  logOut(){
    this.authService.logOut();
  }
  
}
