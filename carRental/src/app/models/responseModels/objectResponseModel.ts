import { ResponseModel } from './responseModel';

export interface ObjectResponseModel<T> extends ResponseModel{
    data:T;
}