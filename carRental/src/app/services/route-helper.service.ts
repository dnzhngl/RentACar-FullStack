import { Injectable } from '@angular/core';
import { ActivatedRoute, NavigationExtras, Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class RouteHelperService {
 // Where we will be storing the values we get from the query string
 arrayOfNumberValues: Array<number> = [];
 arrayOfStringValues: Array<string> = [];
 arrayOfValues: Array<any> = [];

constructor( 
  // We need access to the Angular router object to navigate programatically
  private router: Router,
  // We need use the ActivatedRoute object to get access to information about the current route
  private activatedRoute: ActivatedRoute
) { }

navigateWithArray(parameterName:string, arrayOfParameters:any, navigationUrl:string): void {
  // Create our query parameters object
  // const queryParams:{ [key:string]:any } = {key:parameterName};
  const queryParams:Record<string, any> = {};

  // Create our array of values we want to pass as a query parameter. 
  //Example:
    // const arrayOfParameters = ['a','b','c','d'];
    // const arrayOfValues = arrayOfParameters.map(p => {return p.name;});

  // Add the array of values to the query parameter as a JSON string
  queryParams[`${parameterName}`] = JSON.stringify(arrayOfParameters);

  // Create our 'NaviationExtras' object which is expected by the Angular Router
  const navigationExtras: NavigationExtras = {
    queryParams, queryParamsHandling:'merge'
  };

  // Navigate to component B
  this.router.navigate([`/${navigationUrl}`], navigationExtras);
}

getQueryStringValue(parameterName:string){
   // Get the query string value from our route
   const myArray = this.activatedRoute.snapshot.queryParamMap.get(`${parameterName}`);

   // If the value is null, create a new array and store it
   // Else parse the JSON string we sent into an array
   if (myArray === null) {
     this.arrayOfValues = new Array<number>();
   } else {
     this.arrayOfValues = JSON.parse(myArray);
   }
   return this.arrayOfValues;
}

}
