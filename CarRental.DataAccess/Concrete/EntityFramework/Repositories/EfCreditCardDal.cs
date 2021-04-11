using CarRental.Core.DataAccess.EntityFramework;
using CarRental.DataAccess.Abstract;
using CarRental.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfCreditCardDal : EfEntityRepositoryBase<CreditCard, CarRentalContext>, ICreditCardDal
    {
    }
}
