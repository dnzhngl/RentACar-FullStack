import { ColorService } from 'src/app/services/color.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Color } from 'src/app/models/color';
import {Location} from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-color-add-edit',
  templateUrl: './color-add-edit.component.html',
  styleUrls: ['./color-add-edit.component.css']
})
export class ColorAddEditComponent implements OnInit {

  colorForm:FormGroup;
  isAddMode:boolean;
  selectedColor:Color;

  constructor(
    private formBuilder:FormBuilder,
    private activatedRoute:ActivatedRoute,
    private router:Router,
    private toastrService:ToastrService,
    private colorService:ColorService,
    private location:Location
  ) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => {
      this.createForm();
      if(params['colorId']){
        this.isAddMode = false;
        this.getColor(params['colorId']);
      }
      else{
        this.isAddMode = true;
      }
    });
  }

  onSubmit(){
    if(this.isAddMode){
      this.add();
    } else{
      this.update();
    }
    this.router.navigateByUrl("/admin/colors")
  }

  createForm(){
    this.colorForm = this.formBuilder.group({
      name:['', Validators.required]
    })
  }

  add(){
    if(this.colorForm.valid){
      let color:Color = Object.assign({}, this.colorForm.value);
      this.colorService.add(color).subscribe(response =>{
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

  getColor(colorId:number){
    this.colorService.getById(colorId).subscribe(response => {
      this.selectedColor = response.data;

      this.colorForm.patchValue({
        id:this.selectedColor.id, 
        name:this.selectedColor.name
      });
    });
  }

  update(){
    if(this.colorForm.valid){
      let color:Color = Object.assign({}, this.colorForm.value);
      color.id = this.selectedColor.id;

      this.colorService.update(color).subscribe(response => {
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
