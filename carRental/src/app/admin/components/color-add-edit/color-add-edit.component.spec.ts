import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ColorAddEditComponent as ColorAddEditComponent } from './color-add-edit.component';

describe('ColorAddEditComponent', () => {
  let component: ColorAddEditComponent;
  let fixture: ComponentFixture<ColorAddEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ColorAddEditComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ColorAddEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
