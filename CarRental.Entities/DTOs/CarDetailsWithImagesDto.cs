using CarRental.Core.Entities;
using CarRental.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Entities.DTOs
{
    public class CarDetailsWithImagesDto : IDto
    {
        public int Id { get; set; }
        public byte Capacity { get; set; }
        public string Model { get; set; }
        public string ModelYear { get; set; }
        public double DailyPrice { get; set; }
        public string Description { get; set; }
        public bool IsAvailable { get; set; }
        public int BrandId { get; set; }
        public string Brand { get; set; }
        public int ColorId { get; set; }
        public string Color { get; set; }
        public int CarTypeId { get; set; }
        public string CarType { get; set; }
        public List<CarImageDto> Images { get; set; }
    }
}
