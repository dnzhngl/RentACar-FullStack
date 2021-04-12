import { CarTypeService } from './../../services/car-type.service';
import { CarType } from './../../models/carType';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { ListResponseModel } from 'src/app/models/responseModels/listResponseModel';
import { RouteHelperService } from 'src/app/services/route-helper.service';

@Component({
  selector: 'app-car-type',
  templateUrl: './car-type.component.html',
  styleUrls: ['./car-type.component.css']
})
export class CarTypeComponent implements OnInit {

  result= {} as ListResponseModel<CarType>;
  selectedCarTypes:CarType[]=[];
  filterText="";
  constructor( private carTypeService:CarTypeService,  private routeHelper:RouteHelperService) { }

  ngOnInit(): void {
    this.getCarTypes();
  }

  // @Output() sendCarTypes = new EventEmitter<CarType[]>();

  getCarTypes(){
    this.carTypeService.getCarTypes().subscribe((response)=>{
      this.result.data = response.data;
    })
  }
  remove(){
    this.selectedCarTypes = [];
    this.filterText = "";
    this.routeHelper.clearParams('cartypes')
  }

  handleSelectedCarTypes(carType:CarType){
    if(this.selectedCarTypes.includes(carType)){
      const index = this.selectedCarTypes.indexOf(carType);
      if (index > -1) {
        this.selectedCarTypes.splice(index, 1);
      }
      // this.sendCarTypes.emit(this.selectedCarTypes);
      return;
    }
    this.selectedCarTypes.push(carType);
    // this.sendCarTypes.emit(this.selectedCarTypes);
  }
  navigateData(){
    let carTypes = this.selectedCarTypes.map(c => {return c.name;});
    this.routeHelper.navigateWithArray('cartypes',carTypes, '/cars/search')
  }
}
