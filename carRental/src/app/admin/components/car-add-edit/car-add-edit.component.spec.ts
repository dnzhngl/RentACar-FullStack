import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarAddEditComponent } from './car-add-edit.component';

describe('CarAddEditComponent', () => {
  let component: CarAddEditComponent;
  let fixture: ComponentFixture<CarAddEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CarAddEditComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CarAddEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
