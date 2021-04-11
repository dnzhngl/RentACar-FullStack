using CarRental.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Abstract
{
    public interface ICreditCardService
    {
        IDataResult<List<CreditCard>> GetByCustomerId(int customerId);

        IResult Add(CreditCard creditCard);

        IResult Delete(CreditCard creditCard);

    }
}
