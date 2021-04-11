import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '../../services/auth.service';
import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  FormControl,
  Validators,
} from '@angular/forms';
import { LoginModel } from 'src/app/models/loginModel';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService,
    private toastrService: ToastrService,
    private router:Router,
  ) {}

  ngOnInit(): void {
    this.createLoginForm();
  }

  createLoginForm() {
    this.loginForm = this.formBuilder.group({
      email: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  login() {
    if (this.loginForm.valid) {
      let loginModel: LoginModel = Object.assign({}, this.loginForm.value);
      this.authService.login(loginModel, '')
      this.setTypeOfCustomer();
      }else {
      this.toastrService.warning("Please fill in all fields.", "Attention")
    }
  }

  setTypeOfCustomer(){
    let customer="";
    if(this.router.url === "/login/corporate"){
      customer = "corporate"
    } else if( this.router.url ==="/login/individual"){
      customer = "individual"
    }
    localStorage.setItem("CustomerType", customer);
  }
}
