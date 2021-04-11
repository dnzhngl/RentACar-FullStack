import { ListResponseModel } from './../../../models/responseModels/listResponseModel';
import { BrandService } from './../../../services/brand.service';
import { Brand } from './../../../models/brand';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-brand-list',
  templateUrl: './brand-list.component.html',
  styleUrls: ['./brand-list.component.css']
})
export class BrandListComponent implements OnInit {

  response = {} as ListResponseModel<Brand>;
  brands:Brand[]=[];

  constructor(
    private brandService:BrandService,
    private toastrService:ToastrService
  ) { }

  ngOnInit(): void {
    this.getBrands(); 
  }

  getBrands(){
    this.brandService.getBrands().subscribe(response=>{
      this.brands = response.data;
    }, errorResponse => {
      this.response.message = errorResponse.error.message; 
    })
  }

  delete(brand:Brand){
    this.brandService.delete(brand).subscribe(response => {
      this.toastrService.success(response.message);
      this.getBrands();
    }, errorResponse =>{
      this.toastrService.error(errorResponse.error);
    })
  }

}
