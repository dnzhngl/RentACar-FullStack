import { TestBed } from '@angular/core/testing';

import { AdminLoginGuard } from './admin-login.guard';

describe('AdminLoginGuard', () => {
  let guard: AdminLoginGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(AdminLoginGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
