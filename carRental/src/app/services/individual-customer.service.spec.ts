import { TestBed } from '@angular/core/testing';

import { IndividualCustomerService } from './individual-customer.service';

describe('IndividualCustomerService', () => {
  let service: IndividualCustomerService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(IndividualCustomerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
