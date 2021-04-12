import { NavigationExtras, Router } from '@angular/router';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Color } from 'src/app/models/color';
import { ListResponseModel } from 'src/app/models/responseModels/listResponseModel';
import { ColorService } from 'src/app/services/color.service';
import { RouteHelperService } from 'src/app/services/route-helper.service';

@Component({
  selector: 'app-color',
  templateUrl: './color.component.html',
  styleUrls: ['./color.component.css'],
})
export class ColorComponent implements OnInit {

  result = {} as ListResponseModel<Color>;
  selectedColors: Color[] = [];
  filterText="";
  
  constructor(private colorService: ColorService, private routeHelper:RouteHelperService) {}

  ngOnInit(): void {
    this.getColors();
  }

  // @Output() sendColors = new EventEmitter<Color[]>();

  getColors() {
    this.colorService.getColors().subscribe((response) => {
      this.result.data = response.data;
    });
  }

  remove(){
    this.selectedColors = [];
    this.filterText = "";
    this.routeHelper.clearParams('colors')
  }

  handleSelectedColors(color: Color) {
    if (this.selectedColors.includes(color)) {
      const index = this.selectedColors.indexOf(color);
      if (index > -1) {
        this.selectedColors.splice(index, 1);
      }
      // this.sendColors.emit(this.selectedColors);
      return;
    }
    this.selectedColors.push(color);
    // this.sendColors.emit(this.selectedColors);
  }
  navigateData(){
    let colors = this.selectedColors.map(c => {return c.name;});
    this.routeHelper.navigateWithArray('colors', colors, '/cars/search')
  }
}
