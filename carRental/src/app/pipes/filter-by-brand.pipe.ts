import { Brand } from './../models/brand';
import { CarDetailDto } from './../models/carDetailDto';
import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'filterByBrand',
})
export class FilterByBrandPipe implements PipeTransform {
  transform(value: Brand[], filterText: string): Brand[] {
    filterText = filterText ? filterText.toLocaleLowerCase() : "";
    return filterText ? value.filter((b:Brand) => b.name.toLocaleLowerCase().indexOf(filterText) !== -1) : value;
  }
}






// transform(value: CarDetailDto[], brands: Brand[]): CarDetailDto[] {
//   let carsFiltered: CarDetailDto[] = [];

//   if (brands.length > 0) {
//     brands.forEach((b) => {
//       var filteredArray = value.filter(
//         (c) => c.brand.toLocaleLowerCase() == b.name.toLocaleLowerCase()
//       );
//       carsFiltered = carsFiltered.concat(filteredArray);
//     });
//     return carsFiltered;
//   }
//   return value;
// }










// export class FilterByBrandPipe implements PipeTransform {
//   transform(value: CarDetailDto[], brands: Brand[]): CarDetailDto[] {
//     let carsFiltered: CarDetailDto[] = [];

//     if (brands.length > 0) {
//       brands.forEach((b) => {
//         var filteredArray = value.filter(
//           (c) => c.brand.toLocaleLowerCase() == b.name.toLocaleLowerCase()
//         );
//         carsFiltered = carsFiltered.concat(filteredArray);
//       });
//       return carsFiltered;
//     }
//     return value;
//   }
// }

