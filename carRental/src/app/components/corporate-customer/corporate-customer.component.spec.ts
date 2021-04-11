import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CorporateCustomerComponent } from './corporate-customer.component';

describe('CorporateCustomerComponent', () => {
  let component: CorporateCustomerComponent;
  let fixture: ComponentFixture<CorporateCustomerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CorporateCustomerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CorporateCustomerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
