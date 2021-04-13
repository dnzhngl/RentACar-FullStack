using CarRental.Business.Abstract;
using CarRental.Business.BusinessAspect;
using CarRental.Business.Constants;
using CarRental.Business.ValidationRules.FluentValidation;
using CarRental.Core.Aspects.Autofac.Validation;
using CarRental.DataAccess.Abstract;
using CarRental.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Concrete
{
    public class IndividualCustomerManager : IIndividualCustomerService
    {
        private readonly IIndividualCustomerDal _individualCustomerDal;
        public IndividualCustomerManager(IIndividualCustomerDal individualCustomerDal)
        {
            _individualCustomerDal = individualCustomerDal;
        }

        [ValidationAspect(typeof(IndividualCustomerValidator))]
        public IResult Add(IndividualCustomer customer)
        {
            var result = _individualCustomerDal.Any(c => c.IdentityNo == customer.IdentityNo);
            if (result)
            {
                return new ErrorResult(Messages.IndividualCustomer.Exists(customer.FirstName, customer.LastName));
            }
            _individualCustomerDal.Add(customer);
            return new SuccessResult(Messages.IndividualCustomer.Add(customer.FirstName, customer.LastName));
        }

        [SecuredOperation("admin,individualCustomer.delete,individualCustomer")]
        public IResult Delete(IndividualCustomer customer)
        {
            var result = _individualCustomerDal.Any(c => c.Id == customer.Id);
            if (!result)
            {
                return new ErrorResult(Messages.NotFound());
            }
            _individualCustomerDal.Delete(customer);
            return new SuccessResult(Messages.IndividualCustomer.Delete(customer.FirstName, customer.LastName));
        }

        //[SecuredOperation("admin,individualCustomer.getall")]
        public IDataResult<List<IndividualCustomer>> GetAll()
        {
            var result = _individualCustomerDal.Count();
            if (result > 0)
            {
                return new SuccessDataResult<List<IndividualCustomer>>(_individualCustomerDal.GetAll());
            }
            return new ErrorDataResult<List<IndividualCustomer>>(Messages.NotFound());
        }

        //[SecuredOperation("admin,individualCustomer.get,individualCustomer")]
        public IDataResult<IndividualCustomer> GetByEmail(string email)
        {
            var result = _individualCustomerDal.Get(c => c.Email == email);
            if (result != null)
            {
                return new SuccessDataResult<IndividualCustomer>(result);
            }
            return new ErrorDataResult<IndividualCustomer>(Messages.NotFound());
        }

        [SecuredOperation("admin,individualCustomer.get")]
        public IDataResult<IndividualCustomer> GetById(int customerId)
        {
            var result = _individualCustomerDal.Get(c => c.Id == customerId);
            if (result != null)
            {
                return new SuccessDataResult<IndividualCustomer>(result);
            }
            return new ErrorDataResult<IndividualCustomer>(Messages.NotFound());
        }

        [SecuredOperation("admin,individualCustomer.update,individualCustomer")]
        [ValidationAspect(typeof(IndividualCustomerValidator))]
        public IResult Update(IndividualCustomer customer)
        {
            var result = _individualCustomerDal.Any(c => c.IdentityNo == customer.IdentityNo);
            if (!result)
            {
                return new ErrorResult(Messages.NotFound());
            }
            _individualCustomerDal.Update(customer);
            return new SuccessResult(Messages.IndividualCustomer.Update(customer.FirstName, customer.LastName));
        }
    }
}
