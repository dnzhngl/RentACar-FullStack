import { ActivatedRoute, Router } from '@angular/router';
import { BrandService } from '../../../services/brand.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Brand } from 'src/app/models/brand';

@Component({
  selector: 'app-brand-add-edit',
  templateUrl: './brand-add-edit.component.html',
  styleUrls: ['./brand-add-edit.component.css']
})
export class BrandAddEditComponent implements OnInit {

  brandForm:FormGroup;
  isAddMode:boolean;
  selectedBrand:Brand;

  constructor(
    private formBuilder:FormBuilder,
    private activatedRoute:ActivatedRoute,
    private router:Router,
    private toastrService:ToastrService,
    private brandService:BrandService,
  ) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => {
      this.createForm();
      if(params['brandId']){
        this.isAddMode = false;
        this.getBrand(params['brandId']);
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
    this.router.navigateByUrl("/admin/brands");
    // this.router.navigate(["/admin/brands"]);
  }

  createForm(){
    this.brandForm = this.formBuilder.group({
      name:['', Validators.required]
    });
  }

  add(){
    if(this.brandForm.valid){
      let brand:Brand = Object.assign({}, this.brandForm.value);
      this.brandService.add(brand).subscribe(response =>{
        this.toastrService.success(response.message);
        console.log(response)
      }, (responseError) =>{
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

  getBrand(brandId:number){
    this.brandService.getById(brandId).subscribe(response => {
      this.selectedBrand = response.data;

      this.brandForm.patchValue({
        id:this.selectedBrand.id, 
        name:this.selectedBrand.name
      });
    });
  }

  update(){
    if(this.brandForm.valid){
      let brand:Brand = Object.assign({}, this.brandForm.value);
      brand.id = this.selectedBrand.id;

      this.brandService.update(brand).subscribe(response => {
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
}
