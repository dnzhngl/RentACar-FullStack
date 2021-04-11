import { TestBed } from '@angular/core/testing';

import { CorporateCustomerService } from './corporate-customer.service';

describe('CorporateCustomerService', () => {
  let service: CorporateCustomerService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CorporateCustomerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
