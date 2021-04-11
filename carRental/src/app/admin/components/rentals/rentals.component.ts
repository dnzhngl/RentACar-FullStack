import { ListResponseModel } from './../../../models/responseModels/listResponseModel';
import { ResponseModel } from './../../../models/responseModels/responseModel';
import { ToastrService } from 'ngx-toastr';
import { Component, OnInit } from '@angular/core';
import { RentalDetailDto } from 'src/app/models/rentalDetailDto';
import { RentalService } from 'src/app/services/rental.service';

@Component({
  selector: 'app-rentals',
  templateUrl: './rentals.component.html',
  styleUrls: ['./rentals.component.css']
})
export class RentalsComponent implements OnInit {

  response = {} as ListResponseModel<RentalDetailDto>;

  constructor(
    private rentalService:RentalService, 
    private toastrService:ToastrService
    ) { }

  ngOnInit(): void {
    this.getRentals();
  }

  getRentals(){
    this.rentalService.getRentals().subscribe(response =>{
      this.response = response;
    }, errorResponse => {
      this.response.message = errorResponse.error.message;
    })
  }

  delete(rental:RentalDetailDto){
    this.rentalService.delete(rental).subscribe(response => {
      this.toastrService.success(response.message);
      this.getRentals();
    }, errorResponse =>{
      this.toastrService.error(errorResponse.error);
    })
  }

  update(rental:RentalDetailDto){
    this.rentalService.update(rental).subscribe(response => {
      this.toastrService.success(response.message);
      this.getRentals();
    }, errorResponse =>{
      this.toastrService.error(errorResponse.error);
    })
  }
}
