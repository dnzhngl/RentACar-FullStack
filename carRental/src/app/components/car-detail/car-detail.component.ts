import { CarImageService } from './../../services/car-image.service';
import { ObjectResponseModel } from './../../models/responseModels/objectResponseModel';
import { CarDetailDto } from './../../models/carDetailDto';
import { CarService } from './../../services/car.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-car-detail',
  templateUrl: './car-detail.component.html',
  styleUrls: ['./car-detail.component.css'],
})
export class CarDetailComponent implements OnInit {

  result= {} as ObjectResponseModel<CarDetailDto>;
  carDetail={} as CarDetailDto;
  defaultPicture = "";

  constructor(
    private carService: CarService,
    private carImageService:CarImageService,
    private activatedRoute: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.getDefaultImage();
    this.activatedRoute.params.subscribe((params) => {
      this.getCarDetail(params['carId']);
    });
  }

  getCarDetail(carId: number) {
    this.carService.getCarDetail(carId).subscribe((response) => {
      this.carDetail = response.data;
      this.result = response;
    });
  }

  getDefaultImage(){
    this.defaultPicture = this.carImageService.getDefaultImage()
  }
}
