using CarRental.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarRental.Entities.Concrete
{
    //[Table("IndividualCustomers")]
    public class IndividualCustomer : Customer
    {
        public string IdentityNo { get ; set ; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get ; set ; }
    }
}
