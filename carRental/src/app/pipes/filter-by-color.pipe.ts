import { Pipe, PipeTransform } from '@angular/core';
import { CarDetailDto } from '../models/carDetailDto';
import { Color } from '../models/color';

@Pipe({
  name: 'filterByColor'
})
export class FilterByColorPipe implements PipeTransform {

  transform(value: Color[], filterText: string): Color[] {
    filterText = filterText ? filterText.toLocaleLowerCase() : "";
    return filterText ? value.filter((c:Color) => c.name.toLocaleLowerCase().indexOf(filterText) !== -1) : value;
  }


}


// transform(value: CarDetailDto[], colors: Color[]): CarDetailDto[] {
//   let carsFiltered: CarDetailDto[] = [];

//   if (colors.length > 0) {
//     colors.forEach((color) => {
//       var filteredArray = value.filter(
//         (c) => c.color.toLocaleLowerCase() == color.name.toLocaleLowerCase()
//       );
//       carsFiltered = carsFiltered.concat(filteredArray);
//     });
//     return carsFiltered;
//   }
//   return value;
// }