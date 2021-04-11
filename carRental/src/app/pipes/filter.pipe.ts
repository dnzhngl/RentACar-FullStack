import { CarDetailDto } from './../models/carDetailDto';
import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'filter'
})
export class FilterPipe implements PipeTransform {

  transform(value: CarDetailDto[], filterText: string): CarDetailDto[] {
    filterText = filterText ? filterText.toLocaleLowerCase() : "";
    return filterText ? value.filter((c:CarDetailDto) => c.model.toLocaleLowerCase().indexOf(filterText) !== -1) : value;
  }

}
