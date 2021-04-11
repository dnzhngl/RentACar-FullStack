using AutoMapper;
using CarRental.Core.Entities.Concrete;
using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Helpers
{
    public class AutoMapperHelper :Profile
    {
        public AutoMapperHelper()
        {
            CreateMap<Rental, RentalDetailDto>().ReverseMap();
            CreateMap<Car, CarDetailsWithImagesDto>().ReverseMap();
            CreateMap<CarImage, CarImageDto>().ReverseMap();
            CreateMap<User, UserForRegisterDto>().ReverseMap();
        }
    }
}
