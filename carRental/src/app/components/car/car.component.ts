import { RouteHelperService } from 'src/app/services/route-helper.service';
import { CarType } from './../../models/carType';
import { CarImageService } from './../../services/car-image.service';
import { ListResponseModel } from './../../models/responseModels/listResponseModel';
import { CarDetailDto } from './../../models/carDetailDto';
import { CarService } from './../../services/car.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Brand } from 'src/app/models/brand';
import { Color } from 'src/app/models/color';
import { Location } from '@angular/common';

@Component({
  selector: 'app-car',
  templateUrl: './car.component.html',
  styleUrls: ['./car.component.css'],
})
export class CarComponent implements OnInit {
  carsDetail: CarDetailDto[] = [];
  carDetail = {} as CarDetailDto;
  result = {} as ListResponseModel<CarDetailDto>;
  defaultPicture = '';
  filterText = '';

  selectedBrands: Brand[] = [];
  selectedCarTypes: CarType[] = [];
  selectedColors: Color[] = [];

  constructor(
    private carService: CarService,
    private carImageService: CarImageService,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private routeHelper: RouteHelperService,
  ) {}

  colorsParams: string[] = [];
  brandsParams: string[] = [];
  carTypesParams: string[] = [];

  ngOnInit(): void {
    this.activatedRoute.queryParams.subscribe((params) => {
      this.getDefaultImage();

      this.brandsParams = this.routeHelper.getQueryStringValue('brands');
      this.colorsParams = this.routeHelper.getQueryStringValue('colors');
      this.carTypesParams = this.routeHelper.getQueryStringValue('cartypes');

      if (
        params['rentDate'] &&
        (params['brands'] || params['colors'] || params['cartypes'])
      ) {
        this.getCarsAvailable(params['rentDate'], params['returnDate']);
        this.getCarsByFilters(
          this.brandsParams,
          this.carTypesParams,
          this.colorsParams
        );
      }
      if (params['rentDate']) {
        this.getCarsAvailable(params['rentDate'], params['returnDate']);
      }
      if (params['brands'] || params['colors'] || params['cartypes']) {
        this.getCarsByFilters(
          this.brandsParams,
          this.carTypesParams,
          this.colorsParams
        );
        console.log(this.brandsParams);
      } else {
        this.getCarsWithImages();
        this.router.navigate([], {
          queryParams: { colors: null, brands: null, cartypes: null },
          queryParamsHandling: 'merge',
        });
      }
    });
  }

  getDefaultImage() {
    this.defaultPicture = this.carImageService.getDefaultImage();
  }

  getCarsWithImages() {
    this.carService.getCarsWithImages().subscribe((response) => {
      this.result = response;
    });
  }

  getCarsAvailable(rentDate: Date, returnDate: Date = null) {
    this.carService
      .getCarsAvailableBetweenDates(rentDate, returnDate)
      .subscribe(
        (response) => {
          this.result = response;
        },
        (errorResponse) => {
          console.log('error', errorResponse);
        }
      );
  }

  getCarsByFilters(brands: string[], carTypes: string[], colors: string[]) {
    this.carService.getCarsWithImages().subscribe((response) => {
      this.result = response;
      console.log('renkler', brands, 'türler', carTypes, 'marka', brands);
      if (brands?.length > 0 && colors?.length > 0 && carTypes?.length > 0) {
        this.result.data = this.result.data.filter(
          (c) =>
            brands.includes(c.brand) &&
            colors.includes(c.color) &&
            carTypes.includes(c.carType)
        );
      }
      if (brands.length > 0) {
        console.log('data', this.result.data);
        this.result.data = this.result.data.filter((car) =>
          brands.includes(car.brand)
        );
        console.log('markalar', brands, this.result);
        return this.result.data;
      }
      if (colors.length > 0) {
        this.result.data = this.result.data.filter((car) =>
          colors.includes(car.color)
        );
        console.log('renkler', colors, this.result.data);
        return this.result.data;
      }
      if (carTypes.length > 0) {
        this.result.data = this.result.data.filter((car) =>
          carTypes.includes(car.carType)
        );
        console.log('araba türleri', carTypes, this.result.data);
        return this.result.data;
      }

      return this.result;
    });
  }


  remove(){
    this.filterText = "";
  }
  //#region  get selected items from other components
  getSelectedBrands(brands: Brand[]) {
    this.selectedBrands = brands;
    console.log('brands: ', this.selectedBrands);
  }

  getSelectedCarTypes(carTypes: CarType[]) {
    this.selectedCarTypes = carTypes;
    console.log('carTypes:', this.selectedCarTypes);
  }
  // $event
  getSelectedColors(colors: Color[]) {
    this.selectedColors = colors;
    console.log('colors:', this.selectedColors);
  }
  //#endregion
  //#region Api queries for filters
  getCarDetailsByBrand(brandId: number) {
    this.carService.getCarsByBrand(brandId).subscribe(
      (response) => {
        this.result = response;
        // this.carsDetail = response.data;
      },
      (errorResponse) => {
        this.result.message = errorResponse.error.message;
      }
    );
  }

  getCarDetailsByColor(colorId: number) {
    this.carService.getCarsByColor(colorId).subscribe((response) => {
      this.result = response;
    });
  }

  getCarDetailsByCarType(carTypeId: number) {
    this.carService.getCarsByCarType(carTypeId).subscribe((response) => {
      this.result = response;
    });
  }
  //#endregion
}
