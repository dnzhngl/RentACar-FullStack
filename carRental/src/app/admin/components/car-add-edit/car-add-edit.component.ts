import { CarImageDto } from './../../../models/carImageDto';
import { CarImageService } from './../../../services/car-image.service';
import { CarTypeService } from './../../../services/car-type.service';
import { ColorService } from './../../../services/color.service';
import { CarType } from './../../../models/carType';
import { BrandService } from './../../../services/brand.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl, FormArray } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CarDetailDto } from 'src/app/models/carDetailDto';
import { CarService } from 'src/app/services/car.service';
import { Brand } from 'src/app/models/brand';
import { Color } from 'src/app/models/color';

@Component({
  selector: 'app-car-add-edit',
  templateUrl: './car-add-edit.component.html',
  styleUrls: ['./car-add-edit.component.css']
})
export class CarAddEditComponent implements OnInit {

  brands:Brand[]=[];
  colors:Color[]=[];
  carTypes:CarType[]=[];
  
  carForm:FormGroup;
  isAddMode:boolean;
  carDetailDto = {} as CarDetailDto;

  // For Image Add
  carImageDto:CarImageDto[]=[]
  formData = new FormData();

  constructor(
    private formBuilder:FormBuilder,
    private activatedRoute:ActivatedRoute,
    private router:Router,
    private toastrService:ToastrService,
    private carService:CarService,
    private brandService:BrandService,
    private colorService:ColorService,
    private carTypesService:CarTypeService, 
    private carImageService:CarImageService
  ) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => {
      this.createForm();
      if(params['carId']){
        this.isAddMode = false;
        this.getCar(params['carId']);
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
    this.router.navigateByUrl("/admin/cars");
    // this.router.navigate(["/admin/cars"]);
  }

  createForm(){
    this.carForm = this.formBuilder.group({
      brandId:[this.getBrands(), Validators.required],
      model:['', Validators.required],
      modelYear:['', Validators.required],
      colorId:[this.getColors(), Validators.required],
      carTypeId:[this.getCarTypes(), Validators.required],
      capacity:['', Validators.required],
      dailyPrice:['', Validators.required],
      description:[''],
      isAvailable:[true, Validators.required],
      images:[FormArray, Validators.maxLength(5)]
    });
  }
  
  add(){
    if(this.carForm.valid){
      this.carDetailDto = Object.assign({}, this.carForm.value);
      this.carDetailDto.modelYear = String(this.carDetailDto.modelYear)
      this.carService.add(this.carDetailDto).subscribe(response =>{

        // image ekleme işlemi çalışmıyor. Browserden File tipinde file almam lazım.
        // if(this.carDetailDto.images.length > 0){
        //   this.carImageAdd(this.carDetailDto);
        // }

        this.toastrService.success(response.message);
        console.log(response)
      }, (responseError) =>{
        console.log(responseError)
        if(responseError.error.ValidationErrors){
          for(let i = 0; i < responseError.error.ValidationErrors.length; i++){
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

  // onFileSelect(event:any){
  //   const files:File[] = event.target.files;

  //   if (files.length > 0) {
  //     files.forEach(file => {

  //       formData.append("images", file);
  //     });
  //   }
  // }

  // carImageAdd(car:CarDetailDto, files:File[]){   
  //   this.carImageService.add(car.images).subscribe(res => {
  //     this.toastrService.success(res.message);
  //   }, errRes => {
  //     this.toastrService.error(errRes.error.message);
  //   });
  // }

  getCar(carId:number){
    this.carService.getCarDetail(carId).subscribe(response => {
      this.carDetailDto = response.data;

      this.carForm.patchValue({
        id:this.carDetailDto.id,
        model:this.carDetailDto.model,
        modelYear:this.carDetailDto.modelYear,
        brandId:this.carDetailDto.brandId,
        colorId:this.carDetailDto.colorId,
        carTypeId:this.carDetailDto.carTypeId,
        capacity:this.carDetailDto.capacity,
        dailyPrice:this.carDetailDto.dailyPrice,
        description:this.carDetailDto.description,
        isAvailable:this.carDetailDto.isAvailable,
        images:this.carDetailDto.images
      });
    });
  }

  update(){
    if(this.carForm.valid){
      let car:CarDetailDto = Object.assign({}, this.carForm.value);
      car.id = this.carDetailDto.id;

      this.carService.update(car).subscribe(response => {
      this.toastrService.success(response.message);
    }, responseError =>{
      if(responseError.error.ValidationErrors){
        for(let i = 0; i < responseError.error.ValidationErrors.length; i++){
          this.toastrService.error(responseError.error.ValidationErrors[i].ErrorMessage, "Validation Error");
        }
      }
    });
    } else{
      this.toastrService.warning("Please fill in all fields.", "Attention");
    }
  }

  //#region Dropdown Lists Data
  getBrands(){
    this.brandService.getBrands().subscribe(response=>{
      this.brands = response.data;
    }, errorResponse =>{
      this.toastrService.error(errorResponse.error)
    })
  }

  getColors(){
    this.colorService.getColors().subscribe(response=>{
      this.colors = response.data;
    }, errorResponse =>{
      this.toastrService.error(errorResponse.error)
    })
  }

  getCarTypes(){
    this.carTypesService.getCarTypes().subscribe(response=>{
      this.carTypes = response.data;
    }, errorResponse =>{
      this.toastrService.error(errorResponse.error)
    })
  }
  //#endregion
}
