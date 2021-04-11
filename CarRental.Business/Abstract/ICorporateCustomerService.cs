using CarRental.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Abstract
{
    public interface ICorporateCustomerService
    {
        IDataResult<List<CorporateCustomer>> GetAll();
        IDataResult<CorporateCustomer> GetById(int customerId);
        IDataResult<CorporateCustomer> GetByEmail(string email);
        IResult Add(CorporateCustomer customer);
        IResult Delete(CorporateCustomer customer);
        IResult Update(CorporateCustomer customer);
    }
}
