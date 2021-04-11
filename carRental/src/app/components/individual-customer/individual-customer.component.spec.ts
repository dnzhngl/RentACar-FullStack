import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IndividualCustomerComponent } from './individual-customer.component';

describe('IndividualCustomerComponent', () => {
  let component: IndividualCustomerComponent;
  let fixture: ComponentFixture<IndividualCustomerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ IndividualCustomerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(IndividualCustomerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
