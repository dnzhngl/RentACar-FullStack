import { Customer } from "./customer";

export interface IndividualCustomer extends Customer {
    identityNo:string;
    firstName:string;
    lastName:string;
    dob:Date;
}