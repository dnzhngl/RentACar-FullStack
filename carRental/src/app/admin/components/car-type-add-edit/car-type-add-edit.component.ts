import { CarTypeService } from '../../../services/car-type.service';
import { CarType } from '../../../models/carType';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-car-type-add-edit',
  templateUrl: './car-type-add-edit.component.html',
  styleUrls: ['./car-type-add-edit.component.css']
})
export class CarTypeAddEditComponent implements OnInit {

  carTypeForm:FormGroup;
  isAddMode:boolean;
  selectedCarType:CarType;

  constructor(
    private formBuilder:FormBuilder,
    private activatedRoute:ActivatedRoute,
    private router:Router,
    private toastrService:ToastrService,
    private carTypeService:CarTypeService,
  ) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => {
      this.createForm();
      if(params['carTypeId']){
        this.isAddMode = false;
        this.getCarType(params['carTypeId']);
      }
      else{
        this.isAddMode = true;
      }
    })
  }

  onSubmit(){
    if(this.isAddMode){
      this.add();
    } else{
      this.update();
    }
    this.router.navigateByUrl("/admin/cartypes")
  }

  createForm(){
    this.carTypeForm = this.formBuilder.group({
      name:['', Validators.required]
    })
  }

  add(){
    if(this.carTypeForm.valid){
      let carType:CarType = Object.assign({}, this.carTypeForm.value);
      this.carTypeService.add(carType).subscribe(response =>{
        this.toastrService.success(response.message);
      }, responseError =>{
        if(responseError.error.ValidationErrors){
          for(let i = 0; i < responseError.error.ValidationErrors.length;i++){
            this.toastrService.error(responseError.error.ValidationErrors[i].ErrorMessage, "Validation Error");
          }
        } else if(responseError.error){
          this.toastrService.error(responseError.error.message, "Error");
        }
      });
    } else{
      this.toastrService.warning("Please fill in all fields.", "Attention");
    }
  }

  getCarType(carTypeId:number){
    this.carTypeService.getById(carTypeId).subscribe(response => {
      this.selectedCarType = response.data;

      this.carTypeForm.patchValue({
        id:this.selectedCarType.id, 
        name:this.selectedCarType.name
      });
    });
  }

  update(){
    if(this.carTypeForm.valid){
      let carType:CarType = Object.assign({}, this.carTypeForm.value);
      carType.id = this.selectedCarType.id;

      this.carTypeService.update(carType).subscribe(response => {
      this.toastrService.success(response.message);
    }, responseError =>{
      if(responseError.error.ValidationErrors){
        for(let i = 0; i < responseError.error.ValidationErrors.length;i++){
          this.toastrService.error(responseError.error.ValidationErrors[i].ErrorMessage, "Validation Error");
        }
      }
      console.log(responseError)
    });
    } else{
      this.toastrService.warning("Please fill in all fields.", "Attention");
    }
  }
}
