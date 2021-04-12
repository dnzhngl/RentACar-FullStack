import { CustomerListComponent } from './admin/components/customer-list/customer-list.component';
import { CustomerComponent } from './components/customer/customer.component';
import { UserProfileComponent } from './components/user-profile/user-profile.component';
import { CarAddEditComponent } from './admin/components/car-add-edit/car-add-edit.component';
import { CarListComponent } from './admin/components/car-list/car-list.component';
import { SiteLayoutComponent } from './components/site-layout/site-layout.component';
import { AdminLayoutComponent } from './admin/components/_layout/admin-layout/admin-layout.component';
import { RentalsComponent } from './admin/components/rentals/rentals.component';
import { CarTypeListComponent } from './admin/components/car-type-list/car-type-list.component';
import { ColorListComponent } from './admin/components/color-list/color-list.component';
import { BrandListComponent } from './admin/components/brand-list/brand-list.component';
import { CarTypeAddEditComponent } from './admin/components/car-type-add-edit/car-type-add-edit.component';
import { BrandAddEditComponent } from './admin/components/brand-add-edit/brand-add-edit.component';
import { ColorAddEditComponent } from './admin/components/color-add-edit/color-add-edit.component';
import { AdminHomeComponent } from './admin/components/_layout/admin-home/admin-home.component';
import { AdminLoginComponent } from './admin/components/admin-login/admin-login.component';
import { LoginGuard } from './guards/login.guard';
import { LoginComponent } from './components/login/login.component';
import { HomeComponent } from './components/home/home.component';
import { CarDetailComponent } from './components/car-detail/car-detail.component';
import { CarComponent } from './components/car/car.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RentComponent } from './components/rent/rent.component';
import { AdminLoginGuard } from './admin/guards/admin-login.guard';
import { RentalDetailsComponent } from './admin/components/rental-details/rental-details.component';

const routes: Routes = [

  // Site routes
  {
    path:'',
    component:SiteLayoutComponent,
    children:[
      {path:"",pathMatch:"full", component: HomeComponent},
      {path:"cars", component: CarComponent},
      
      {path:"cars/:rentDate&:returnDate", component: CarComponent},
      {path:"cars/:rentDate", component: CarComponent},

      {path:"cars/search", component: CarComponent},
      {path:"cars/:brandId/:colorId/:carTypeId", component: CarComponent},
      {path:"cars/:brands/:colors/:carTypes", component: CarComponent},

      {path:"cars/color/:colorId", component: CarComponent},
      {path:"cars/brand/:brandId", component: CarComponent},
      {path:"cars/cartype/:carTypeId", component: CarComponent},

      {path:"cars/details/:carId", component: CarDetailComponent},
      {path:"cars/rent/:carId", component: RentComponent, canActivate:[LoginGuard]},
      {path:"profile/individual/:individualCustomer", component: UserProfileComponent, canActivate:[LoginGuard]},
      {path:"profile/corporate/:corporateCustomer", component: UserProfileComponent, canActivate:[LoginGuard]}
    ]
  },


  // Admin routes
  {
    path:'',
    component: AdminLayoutComponent,
    children:[
      {path:"admin/home", component: AdminHomeComponent, canActivate:[AdminLoginGuard]},
      
      {path:"admin/colors/add", component: ColorAddEditComponent, canActivate:[AdminLoginGuard]},
      {path:"admin/colors/edit/:colorId", component: ColorAddEditComponent, canActivate:[AdminLoginGuard]},
      {path:"admin/colors", component: ColorListComponent, canActivate:[AdminLoginGuard]},

      {path:"admin/brands/add", component: BrandAddEditComponent, canActivate:[AdminLoginGuard]},
      {path:"admin/brands/edit/:brandId", component: BrandAddEditComponent, canActivate:[AdminLoginGuard]}, 
      {path:"admin/brands", component: BrandListComponent, canActivate:[AdminLoginGuard]},

      {path:"admin/cartypes/add", component: CarTypeAddEditComponent, canActivate:[AdminLoginGuard]},
      {path:"admin/cartypes/edit/:carTypeId", component: CarTypeAddEditComponent, canActivate:[AdminLoginGuard]}, 
      {path:"admin/cartypes", component: CarTypeListComponent, canActivate:[AdminLoginGuard]},

      {path:"admin/cars/add", component: CarAddEditComponent, canActivate:[AdminLoginGuard]},
      {path:"admin/cars/edit/:carId", component: CarAddEditComponent, canActivate:[AdminLoginGuard]},
      {path:"admin/cars", component: CarListComponent, canActivate:[AdminLoginGuard]},

      {path:"admin/rentals", component: RentalsComponent, canActivate:[AdminLoginGuard]},
      {path:"admin/rentals/details/:rentalId", component: RentalDetailsComponent, canActivate:[AdminLoginGuard]},

      {path:"admin/customers", component: CustomerListComponent, canActivate:[AdminLoginGuard]},
    ],
    // resolve:{results: ExampleRootResolver},
    // runGuardsAndResolvers:'always'
  },

  //no Layouts
  {path:"login/corporate", component: LoginComponent},
  {path:"login/individual", component: LoginComponent},
  {path:"admin/login", component: AdminLoginComponent},
  {path:"admin/logout", component: AdminLoginComponent},

  // otherwise redirect to home
  {path:'**', redirectTo:''}
];

@NgModule({
  imports: [RouterModule.forRoot(routes/*, {onSameUrlNavigation:'reload'}*/)],
  exports: [RouterModule]
})
export class AppRoutingModule { }