using CarRental.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Entities.Concrete
{
    public class Car : IEntity
    {
        public int Id { get; set; }
        public byte Capacity { get; set; }
        public string Model { get; set; }
        public string ModelYear { get; set; }
        public double DailyPrice { get; set; }
        public string Description { get; set; }
        public bool IsAvailable { get; set; } = true;

        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }

        public int CarTypeId { get; set; }
        public virtual CarType CarType { get; set; }

        public int ColorId { get; set; }
        public virtual Color Color { get; set; }

        public ICollection<CarImage> Images { get; set; }
        public ICollection<Rental> Rentals { get; set; }
        //public ICollection<RentedCar> RentedCars { get; set; }
    }
}
