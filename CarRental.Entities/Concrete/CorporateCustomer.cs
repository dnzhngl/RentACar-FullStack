using CarRental.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarRental.Entities.Concrete
{
    //[Table("CorporateCustomers")]
    public class CorporateCustomer : Customer
    {
        public string CompanyName { get; set; }
        public string TaxNumber { get; set; }
    }
}
