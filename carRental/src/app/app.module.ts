import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ColorComponent } from './components/color/color.component';
import { NaviComponent } from './components/navi/navi.component';
import { BrandComponent } from './components/brand/brand.component';
import { CarComponent } from './components/car/car.component';
import { CustomerComponent } from './components/customer/customer.component';
import { IndividualCustomerComponent } from './components/individual-customer/individual-customer.component';
import { CorporateCustomerComponent } from './components/corporate-customer/corporate-customer.component';
import { RentalsComponent } from './admin/components/rentals/rentals.component';
import { CarTypeComponent } from './components/car-type/car-type.component';
import { CarDetailComponent } from './components/car-detail/car-detail.component';
import { HomeComponent } from './components/home/home.component';
import { FilterPipe } from './pipes/filter.pipe';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FilterByBrandPipe } from './pipes/filter-by-brand.pipe';
import { AuthInterceptor } from './interceptors/auth.interceptor';
import { LoginComponent } from './components/login/login.component';
import { FilterByMultiplePipe } from './pipes/filter-by-multiple.pipe';
import { FilterByColorPipe } from './pipes/filter-by-color.pipe';
import { FilterByCarTypePipe } from './pipes/filter-by-car-type.pipe';
import { RentComponent } from './components/rent/rent.component';
import { ToastrModule } from 'ngx-toastr';
import { AgePipe } from './pipes/age.pipe';
import { AdminLoginComponent } from './admin/components/admin-login/admin-login.component';
import { AdminHomeComponent } from './admin/components/_layout/admin-home/admin-home.component';
import { ColorAddEditComponent } from './admin/components/color-add-edit/color-add-edit.component';
import { BrandAddEditComponent } from './admin/components/brand-add-edit/brand-add-edit.component';
import { CarTypeAddEditComponent } from './admin/components/car-type-add-edit/car-type-add-edit.component';
import { BrandListComponent } from './admin/components/brand-list/brand-list.component';
import { ColorListComponent } from './admin/components/color-list/color-list.component';
import { CarTypeListComponent } from './admin/components/car-type-list/car-type-list.component';
import { AdminLayoutComponent } from './admin/components/_layout/admin-layout/admin-layout.component';
import { SiteLayoutComponent } from './components/site-layout/site-layout.component';
import { AdminHeaderComponent } from './admin/components/_layout/admin-header/admin-header.component';
import { CarListComponent } from './admin/components/car-list/car-list.component';
import { AdminSidebarComponent } from './admin/components/_layout/admin-sidebar/admin-sidebar.component';
import { CarAddEditComponent } from './admin/components/car-add-edit/car-add-edit.component';
import { RentalDetailsComponent } from './admin/components/rental-details/rental-details.component';
import { UserProfileComponent } from './components/user-profile/user-profile.component';
import { PaymentComponent } from './components/payment/payment.component';
import { AdminFooterComponent } from './admin/components/_layout/admin-footer/admin-footer.component';
import { CustomerListComponent } from './admin/components/customer-list/customer-list.component';
import { RegisterComponent } from './components/register/register.component';

@NgModule({
  declarations: [
    AppComponent,
    ColorComponent,
    NaviComponent,
    BrandComponent,
    CarComponent,
    CustomerComponent,
    IndividualCustomerComponent,
    CorporateCustomerComponent,
    RentalsComponent,
    CarTypeComponent,
    CarDetailComponent,
    HomeComponent,
    FilterPipe,
    FilterByBrandPipe,
    LoginComponent,
    FilterByMultiplePipe,
    FilterByColorPipe,
    FilterByCarTypePipe,
    RentComponent,
    AgePipe,
    AdminLoginComponent,
    AdminHomeComponent,
    ColorAddEditComponent,
    BrandAddEditComponent,
    CarTypeAddEditComponent,
    BrandListComponent,
    ColorListComponent,
    CarTypeListComponent,
    AdminLayoutComponent,
    SiteLayoutComponent,
    AdminHeaderComponent,
    CarListComponent,
    AdminSidebarComponent,
    CarAddEditComponent,
    RentalDetailsComponent,
    UserProfileComponent,
    PaymentComponent,
    AdminFooterComponent,
    CustomerListComponent,
    RegisterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    ToastrModule.forRoot({
      positionClass: "toast-bottom-right"
    }),
    BrowserAnimationsModule,
  ],
  providers: [
    {provide:HTTP_INTERCEPTORS, useClass:AuthInterceptor, multi:true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
