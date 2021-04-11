using CarRental.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Entities.Concrete
{
    public class Rental : IEntity
    {
        public int Id { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public double? TotalPrice { get; set; }
        public float? Discount { get; set; }


        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public int CarId { get; set; }
        public virtual Car Car { get; set; }
    }
}
