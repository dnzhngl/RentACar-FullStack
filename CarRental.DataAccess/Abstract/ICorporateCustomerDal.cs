using CarRental.Core.DataAccess;
using CarRental.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.DataAccess.Abstract
{
    public interface ICorporateCustomerDal : IEntityRepository<CorporateCustomer>
    {
    }
}
