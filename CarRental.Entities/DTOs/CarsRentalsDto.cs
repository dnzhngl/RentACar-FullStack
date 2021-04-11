using CarRental.Core.Entities;
using CarRental.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRental.Entities.DTOs
{
    public class CarsRentalsDto :IDto
    {
        public Car Car { get; set; }
        public ICollection<Rental> Rentals { get; set; }
    }
}
