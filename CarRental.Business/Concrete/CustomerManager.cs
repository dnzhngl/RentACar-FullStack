using CarRental.Business.Abstract;
using CarRental.Business.Constants;
using CarRental.DataAccess.Abstract;
using CarRental.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRental.Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult();

        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult();
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public IDataResult<Customer> GetByEmail(string email)
        {
            var result = _customerDal.Any(c => c.Email == email);
            if (result)
            {
                return new SuccessDataResult<Customer>(_customerDal.Get(c => c.Email == email));
            }
            return new ErrorDataResult<Customer>(Messages.NotFound());
        }

        public IDataResult<Customer> GetById(int userId)
        {
            var result = _customerDal.Any(c => c.Id == userId);
            if (result)
            {
                return new SuccessDataResult<Customer>(_customerDal.Get(c => c.Id == userId));
            }
            return new ErrorDataResult<Customer>(Messages.NotFound());
        }

        public IResult Update(Customer customer)
        {
            var result = _customerDal.Any(c => c.Id == customer.Id);
            if (result)
            {
                _customerDal.Update(customer);
                return new SuccessResult();
            }
            return new ErrorResult(Messages.NotFound());
        } 

    }
}
