export interface RentalDetailDto{
    id:number;
    customerName:string;
    carId:number;
    brand:string;
    model:string;
    color:string;
    carType:string;
    rentDate:Date;
    returnDate:Date;
    discount:number;
    totalPrice:number;
}