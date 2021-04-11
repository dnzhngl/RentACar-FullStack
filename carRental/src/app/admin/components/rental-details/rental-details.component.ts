import { RentalService } from './../../../services/rental.service';
import { Component, OnInit } from '@angular/core';
import { ObjectResponseModel } from 'src/app/models/responseModels/objectResponseModel';
import { RentalDetailDto } from 'src/app/models/rentalDetailDto';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-rental-details',
  templateUrl: './rental-details.component.html',
  styleUrls: ['./rental-details.component.css']
})
export class RentalDetailsComponent implements OnInit {

  result = {} as ObjectResponseModel<RentalDetailDto>;

  constructor(
    private rentalService:RentalService,
    private activatedRoute: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => {
      this.getRental(params['rentalId']);
    })
  }

  getRental(rentalId:number){
    this.rentalService.getRentalDetail(rentalId).subscribe(response =>{
      this.result = response
    })
  }
}
