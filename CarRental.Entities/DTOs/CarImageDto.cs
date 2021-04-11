using CarRental.Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Entities.DTOs
{
    /// <summary>
    /// Stands for the car image entity with an image field in type of IFormFile and image path in type of string.
    /// </summary>
    public class CarImageDto : IDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string ImagePath { get; set; }
        public IFormFile Image { get; set; }
    }
}
