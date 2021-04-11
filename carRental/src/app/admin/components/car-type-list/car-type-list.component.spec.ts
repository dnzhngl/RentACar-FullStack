import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarTypeListComponent } from './car-type-list.component';

describe('CarTypeListComponent', () => {
  let component: CarTypeListComponent;
  let fixture: ComponentFixture<CarTypeListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CarTypeListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CarTypeListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
