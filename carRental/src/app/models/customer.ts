import { User } from "./user";

export interface Customer extends User{
    phoneNumber:string;
    address:string;
}