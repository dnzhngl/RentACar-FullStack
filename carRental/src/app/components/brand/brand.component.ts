import { RouteHelperService } from './../../services/route-helper.service';
import { NavigationExtras, Router } from '@angular/router';
import { ListResponseModel } from './../../models/responseModels/listResponseModel';
import { BrandService } from './../../services/brand.service';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Brand } from 'src/app/models/brand';

@Component({
  selector: 'app-brand',
  templateUrl: './brand.component.html',
  styleUrls: ['./brand.component.css'],
})
export class BrandComponent implements OnInit {
  
  result = {} as ListResponseModel<Brand>;
  selectedBrands: Brand[] = [];
  filterText = '';

  constructor(private brandService: BrandService, private routeHelper:RouteHelperService) {}
  
  ngOnInit(): void {
    this.getBrands();
  }

  // @Output() sendBrands = new EventEmitter<Brand[]>();

  getBrands() {
    this.brandService.getBrands().subscribe((response) => {
      this.result.data = response.data;
    });
  }
  remove(){
    this.selectedBrands = [];
    this.filterText = "";
    this.routeHelper.clearParams('brands')
  }
  handleSelectedBrands(brand: Brand) {
    if (this.selectedBrands.includes(brand)) {
      const index = this.selectedBrands.indexOf(brand);
      if (index > -1) {
        this.selectedBrands.splice(index, 1);
      }
      // this.sendBrands.emit(this.selectedBrands);
      return;
    }
    this.selectedBrands.push(brand);
    // this.sendBrands.emit(this.selectedBrands);
  }

  navigateData(){
    let brands = this.selectedBrands.map(c => {return c.name;});
    this.routeHelper.navigateWithArray('brands',brands, '/cars/search')
  }
}
