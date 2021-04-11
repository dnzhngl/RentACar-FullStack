export interface Rental{
    id:number;
    customerId:number;
    carId:number;
    
    rentDate:Date;
    returnDate:Date;
    discount:number;
    totalPrice:number;
}