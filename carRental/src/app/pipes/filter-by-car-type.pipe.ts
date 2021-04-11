import { CarType } from './../models/carType';
import { Pipe, PipeTransform } from '@angular/core';
import { CarDetailDto } from '../models/carDetailDto';

@Pipe({
  name: 'filterByCarType'
})
export class FilterByCarTypePipe implements PipeTransform {
  transform(value: CarType[], filterText: string): CarType[] {
    filterText = filterText ? filterText.toLocaleLowerCase() : "";
    return filterText ? value.filter((c:CarType) => c.name.toLocaleLowerCase().indexOf(filterText) !== -1) : value;
  }
}

// transform(value: CarDetailDto[], carTypes: CarType[]): CarDetailDto[] {
//   let carsFiltered: CarDetailDto[] = [];

//   if (carTypes.length > 0) {
//     carTypes.forEach((ct) => {
//       var filteredArray = value.filter(
//         (c) => c.carType.toLocaleLowerCase() == ct.name.toLocaleLowerCase()
//       );
//       carsFiltered = carsFiltered.concat(filteredArray);
//     });
//     return carsFiltered;
//   }
//   return value;
// }