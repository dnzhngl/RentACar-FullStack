import { Color } from './../../../models/color';
import { Component, OnInit } from '@angular/core';
import { ListResponseModel } from 'src/app/models/responseModels/listResponseModel';
import { ColorService } from 'src/app/services/color.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-color-list',
  templateUrl: './color-list.component.html',
  styleUrls: ['./color-list.component.css']
})
export class ColorListComponent implements OnInit {

  response = {} as ListResponseModel<Color>;
  colors:Color[]=[];

  constructor(
    private colorService:ColorService,
    private toastrService:ToastrService
  ) { }

  ngOnInit(): void {
    this.getColors();
  }

  getColors(){
    this.colorService.getColors().subscribe(response=>{
      this.colors = response.data;
    }, errorResponse => {
      this.response.message = errorResponse.error.message; 
    })
  }

  delete(color:Color){
    this.colorService.delete(color).subscribe(response => {
      this.toastrService.success(response.message);
      this.getColors();
    }, errorResponse =>{
      this.toastrService.error(errorResponse.error);
    })
  }

  update(color:Color){
    this.colorService.update(color).subscribe(response => {
      this.toastrService.success(response.message);
      this.getColors();
    }, errorResponse =>{
      this.toastrService.error(errorResponse.error);
    })
  }

}
