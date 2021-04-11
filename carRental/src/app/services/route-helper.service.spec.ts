import { TestBed } from '@angular/core/testing';

import { RouteHelperService } from './route-helper.service';

describe('RouteHelperService', () => {
  let service: RouteHelperService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RouteHelperService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
