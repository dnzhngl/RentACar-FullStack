using CarRental.Core.DataAccess.EntityFramework;
using CarRental.DataAccess.Abstract;
using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfIndividualCustomerDal : EfEntityRepositoryBase<IndividualCustomer, CarRentalContext>, IIndividualCustomerDal
    {
    }
}
