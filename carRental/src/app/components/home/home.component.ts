import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import * as moment from 'moment';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  rentDate: Date = null;
  returnDate: Date = null;

  constructor(private router: Router) {}

  ngOnInit(): void {}

  navigateToCars() {
    console.log(this.rentDate, this.returnDate);
    this.router.navigate(['/cars'], {
      queryParams: { rentDate: this.rentDate, returnDate: this.returnDate },
    });
  }
}
