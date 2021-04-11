using CarRental.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Abstract
{
    public interface IIndividualCustomerService
    {
        IDataResult<List<IndividualCustomer>> GetAll();
        IDataResult<IndividualCustomer> GetById(int customerId);
        IDataResult<IndividualCustomer> GetByEmail(string email);
        IResult Add(IndividualCustomer customer);
        IResult Delete(IndividualCustomer customer);
        IResult Update(IndividualCustomer customer);
    }
}
