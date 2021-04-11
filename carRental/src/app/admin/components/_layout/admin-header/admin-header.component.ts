import { AuthService } from 'src/app/services/auth.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin-header',
  templateUrl: './admin-header.component.html',
  styleUrls: ['./admin-header.component.css']
})
export class AdminHeaderComponent implements OnInit {

  userName:string;

  constructor(
    private authService:AuthService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.userName = this.authService.userName;
  }

  isLoggedIn(){
    this.authService.isAuthenticated();
  }

  logOut(){
    this.authService.logOut();
    this.router.navigateByUrl("/admin/login");
  }
}
