import { TestBed } from '@angular/core/testing';

import { CarTypeService } from './car-type.service';

describe('CarTypeService', () => {
  let service: CarTypeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CarTypeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
