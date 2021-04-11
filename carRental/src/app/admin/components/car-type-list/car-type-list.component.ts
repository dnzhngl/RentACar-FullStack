import { CarType } from './../../../models/carType';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { ListResponseModel } from 'src/app/models/responseModels/listResponseModel';
import { CarTypeService } from 'src/app/services/car-type.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-car-type-list',
  templateUrl: './car-type-list.component.html',
  styleUrls: ['./car-type-list.component.css']
})
export class CarTypeListComponent implements OnInit {

  // response:ListResponseModel<CarType>;
  response = {} as ListResponseModel<CarType>;

  carTypes:CarType[]=[];

  constructor(
    private carTypeService:CarTypeService,
    private toastrService:ToastrService
  ) { }

  ngOnInit(): void {
    this.getCarTypes();
  }

  getCarTypes(){
    this.carTypeService.getCarTypes().subscribe(response=>{
      this.carTypes = response.data;
    }, errorResponse => {
      this.response.message = errorResponse.error.message; 
    })
  }

  delete(carType:CarType){
    this.carTypeService.delete(carType).subscribe(response => {
      this.toastrService.success(response.message);
      this.getCarTypes();
    }, errorResponse =>{
      this.toastrService.error(errorResponse.error);
    })
  }
}
