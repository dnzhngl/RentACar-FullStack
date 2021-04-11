using CarRental.Core.Entities;
using CarRental.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarRental.Entities.Concrete
{
    //[Table("Customers")]
    public class Customer : User
    {
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Rental> Rentals { get; set; }
        public ICollection<CreditCard> CreditCards { get; set; }
    }
}
