import { Customer } from "./customer";

export interface CorporateCustomer extends Customer{
    companyName:string;
    taxNumber:string;
}