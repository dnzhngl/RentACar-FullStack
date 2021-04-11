import { Pipe, PipeTransform } from '@angular/core';
import { Brand } from '../models/brand';
import { CarDetailDto } from '../models/carDetailDto';
import { CarType } from '../models/carType';
import { Color } from '../models/color';

@Pipe({
  name: 'filterByMultiple',
})
export class FilterByMultiplePipe implements PipeTransform {
  transform(
    value: CarDetailDto[],
    brands: Brand[],
    colors: Color[],
    carTypes: CarType[]
  ): CarDetailDto[] {
    
    let carsFiltered: CarDetailDto[] = [];

    if (brands.length > 0) {
      brands.forEach((b) => {
        var filteredByBrand = value.filter(
          (c) => c.brand.toLocaleLowerCase() === b.name.toLocaleLowerCase()
        );
        carsFiltered = carsFiltered.concat(filteredByBrand);
      });
      value = carsFiltered;
    }
    if (colors.length > 0) {
      colors.forEach((color) => {
        let filteredByColor = carsFiltered.filter(
          (c) => c.color.toLocaleLowerCase() === color.name.toLocaleLowerCase()
        );
        carsFiltered = carsFiltered.concat(filteredByColor);
      });
      value = carsFiltered;
    }
    if (carTypes.length > 0) {
      carTypes.forEach((ct) => {
        let filteredByCarType = carsFiltered.filter(
          (c) => c.carType.toLocaleLowerCase() === ct.name.toLocaleLowerCase()
        );
        carsFiltered = carsFiltered.concat(filteredByCarType);
      });
      value = carsFiltered;
    }
    return value;
  }
}
