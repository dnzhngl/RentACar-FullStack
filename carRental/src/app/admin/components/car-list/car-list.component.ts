import { CarService } from './../../../services/car.service';
import { CarDetailDto } from './../../../models/carDetailDto';
import { Component, OnInit } from '@angular/core';
import { ListResponseModel } from 'src/app/models/responseModels/listResponseModel';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-car-list',
  templateUrl: './car-list.component.html',
  styleUrls: ['./car-list.component.css']
})
export class CarListComponent implements OnInit {

  response = {} as ListResponseModel<CarDetailDto>;

  constructor(
    private carService:CarService,
    private toastrService:ToastrService
  ) { }

  ngOnInit(): void {
    this.getAllCars();
  }

  getAllCars(){
    this.carService.getCarsDetailDto().subscribe(response=>{
      this.response = response;
    }, errorResponse => {
      this.response.message = errorResponse.error.message; 
    })
  }

  delete(carDetailDto:CarDetailDto){
    this.carService.delete(carDetailDto).subscribe(response => {
      this.toastrService.success(response.message);
      this.getAllCars();
    }, errorResponse =>{
      this.toastrService.error(errorResponse.error);
    })
  }
}
