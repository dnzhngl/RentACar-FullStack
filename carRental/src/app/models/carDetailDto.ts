import { CarImageDto } from './carImageDto';

export interface CarDetailDto {
  id: number;
  capacity: number;
  model: string;
  modelYear: string;
  dailyPrice: number;
  description: string;
  isAvailable: boolean;

  brand: string;
  carType: string;
  color: string;

  brandId:number;
  carTypeId:number;
  colorId:number;

  images:CarImageDto[];
}
