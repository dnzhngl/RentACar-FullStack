import { CarService } from './../../services/car.service';
import { CarDetailDto } from './../../models/carDetailDto';
import { IndividualCustomerService } from './../../services/individual-customer.service';
import { IndividualCustomer } from './../../models/individualCustomer';
import { ToastrService } from 'ngx-toastr';
import { RentalService } from './../../services/rental.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ObjectResponseModel } from 'src/app/models/responseModels/objectResponseModel';
import { ActivatedRoute } from '@angular/router';
import { ThrowStmt } from '@angular/compiler';

@Component({
  selector: 'app-rent',
  templateUrl: './rent.component.html',
  styleUrls: ['./rent.component.css']
})
export class RentComponent implements OnInit {

  clicked:boolean=false;
  rentForm: FormGroup;
  currentCustomer = {} as IndividualCustomer;
  selectedCar = {} as CarDetailDto;
  calculatedTotalPrice:number;

  constructor(
    private formBuilder:FormBuilder,
    private rentalService:RentalService,
    private toastrService:ToastrService,
    private individualCustomerService:IndividualCustomerService,
    private carService:CarService,
    private activatedRoute: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params =>{
      if(params['carId']){
        this.getCurrentCustomer();
        this.getCarToBeRented(Number(params['carId']));
        this.createRentForm();
      }
    })
  }

 createRentForm(){
    this.rentForm = this.formBuilder.group({
      rentDate:['', Validators.required],
      returnDate:[''],
      totalPrice:[this.selectedCar.dailyPrice],
      carId:[this.selectedCar.id, Validators.required],
      customerId:[this.currentCustomer.id, Validators.required]
    })
  }

  checkForm(){
    if(this.rentForm.valid){
      this.rentForm.patchValue({totalPrice: this.calculatedTotalPrice ? this.calculatedTotalPrice : this.selectedCar.dailyPrice });
    } else {
      this.toastrService.warning("Please fill in all fields.", "Attention")
    }
  }

 async getCurrentCustomer(){
    this.individualCustomerService.getCurrentCustomer().subscribe(response => {
      this.currentCustomer = response.data;
      this.rentForm.patchValue({
        customerId : this.currentCustomer.id
      })
    })
  }

 getCarToBeRented(carId:number){
    this.carService.getCarDetail(carId).subscribe(response =>{
      this.selectedCar = response.data;
      this.rentForm.patchValue({
        carId : this.selectedCar.id,
        totalPrice: this.selectedCar.dailyPrice
      })
    })
  }

  calculateTotalPrice(){
    let rentDate:Date = this.rentForm.controls['rentDate'].value;
    let returnDate:Date = this.rentForm.controls['returnDate'].value;
    var numberOfDays = this.calculateDays(rentDate, returnDate);
    this.calculatedTotalPrice = numberOfDays * this.selectedCar.dailyPrice;
  }

  // Returns the number of days between given dates
  calculateDays(date1:any, date2:any) {
    var date1:any = new Date(date1);
    var date2:any = new Date(date2);
    var diffDays:any = Math.floor((date2 - date1) / (1000 * 60 * 60 * 24));
    return diffDays;
  }
}
