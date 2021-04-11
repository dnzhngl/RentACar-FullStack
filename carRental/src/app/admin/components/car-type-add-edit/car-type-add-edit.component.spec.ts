import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarTypeAddEditComponent as CarTypeAddEditComponent } from './car-type-add-edit.component';

describe('CarTypeAddEditComponent', () => {
  let component: CarTypeAddEditComponent;
  let fixture: ComponentFixture<CarTypeAddEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CarTypeAddEditComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CarTypeAddEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
