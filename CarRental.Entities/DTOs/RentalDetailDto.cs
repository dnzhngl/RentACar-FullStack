using CarRental.Core.Entities;
using CarRental.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Entities.DTOs
{
    public class RentalDetailDto : IDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        public int CarId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string CarType { get; set; }
        

        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public double? TotalPrice { get; set; }
        public float? Discount { get; set; }
    }
}
