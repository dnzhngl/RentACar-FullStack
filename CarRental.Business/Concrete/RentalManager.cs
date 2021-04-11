using AutoMapper;
using CarRental.Business.Abstract;
using CarRental.Business.BusinessAspect;
using CarRental.Business.Constants;
using CarRental.Business.ValidationRules.FluentValidation;
using CarRental.Core.Aspects.Autofac.Caching;
using CarRental.Core.Aspects.Autofac.Transaction;
using CarRental.Core.Aspects.Autofac.Validation;
using CarRental.DataAccess.Abstract;
using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private readonly IRentalDal _rentalDal;
        private readonly IMapper _mapper;
        public RentalManager(IRentalDal rentalDal, IMapper mapper)
        {
            _rentalDal = rentalDal;
            _mapper = mapper;
        }

        [SecuredOperation("admin,rental.add,customer")]
        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalManager.Get")]
        [CacheRemoveAspect("ICarManager.Get")]
        [TransactionScopeAspect]
        public IResult Add(RentalDetailDto rentalDto)
        {
            var result = _rentalDal.Any(r => r.CarId == rentalDto.CarId && (r.ReturnDate == null || r.ReturnDate >= rentalDto.RentDate));
            if (!result)
            {
                var rental = _mapper.Map<Rental>(rentalDto);
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.Rental.Add());
            }
            return new ErrorResult(Messages.Rental.Exists());
        }

        [SecuredOperation("admin,customer")]
        [CacheRemoveAspect("IRentalManager.Get")]
        public IResult Delete(RentalDetailDto rentalDto)
        {
            var result = _rentalDal.Get(a => a.Id == rentalDto.Id);
            if (result != null)
            {
                var rental = _mapper.Map<Rental>(rentalDto);
                _rentalDal.Delete(rental);
                return new SuccessResult(Messages.Rental.Delete());
            }
            return new ErrorResult(Messages.NotFound());
        }

        [SecuredOperation("admin,rental.getall")]
        public IDataResult<List<Rental>> GetAll()
        {
            var result = _rentalDal.Count();
            if (result > 0)
            {
                return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
            }
            return new ErrorDataResult<List<Rental>>(Messages.NotFound());
        }

        /// <summary>
        /// Get rentals detailed information that are not returned yet.
        /// </summary>
        /// <returns>If founds any, returns SuccessDataResult with a list of RentalDetailDto, else return ErrorDataResult with an error message.</returns>
        [SecuredOperation("admin,rental.getall")]
        public IDataResult<List<RentalDetailDto>> GetAllNotReturnedRentalsDetails()
        {
            var result = _rentalDal.Count(r => r.ReturnDate == null);
            if (result > 0)
            {
                return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetAllRentalsDetails(r => r.ReturnDate == null));
            }
            return new ErrorDataResult<List<RentalDetailDto>>(Messages.NotFound());
        }

        /// <summary>
        /// Get rentals detailed information.
        /// </summary>
        /// <returns>If founds any, returns SuccessDataResult with a list of RentalDetailDto, else return ErrorDataResult with an error message.</returns>
        [SecuredOperation("admin,rental.getall")]
        public IDataResult<List<RentalDetailDto>> GetAllRentalsDetails()
        {
            var result = _rentalDal.Any(r => r.RentDate != null);
            if (result)
            {
                return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetAllRentalsDetails());
            }
            return new ErrorDataResult<List<RentalDetailDto>>(Messages.NotFound());
        }

        [SecuredOperation("admin,rental.get,customer")]
        public IDataResult<Rental> GetById(int rentalId)
        {
            var result = _rentalDal.Get(a => a.Id == rentalId);
            if (result != null)
            {
                return new SuccessDataResult<Rental>(result);
            }
            return new ErrorDataResult<Rental>(Messages.NotFound());
        }

       
        /// <summary>
        /// Gets rental details that has the given rentalId.
        /// </summary>
        /// <param name="rentalId">Rental id must be given of type integer.</param>
        /// <returns>Returns SuccessDataResult with data of type RentalDetailDto if found any, else returns ErrorDataResult with an error message.</returns>
        [SecuredOperation("admin,rental.getdetail,customer")]
        [CacheAspect]
        public IDataResult<RentalDetailDto> GetRentalDetails(int rentalId)
        {
            var result = _rentalDal.Any(r => r.Id == rentalId);
            if (!result)
            {
                return new ErrorDataResult<RentalDetailDto>(Messages.NotFound());
            }
            return new SuccessDataResult<RentalDetailDto>(_rentalDal.GetRentalDetails(rentalId));
        }

        [SecuredOperation("admin,rental.update")]
        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalManager.Get")]
        public IResult Update(RentalDetailDto rentalDto)
        {
            var result = _rentalDal.Get(a => a.Id == rentalDto.Id);
            if (result != null)
            {
                var rental = _mapper.Map<Rental>(rentalDto);
                _rentalDal.Update(rental);
                return new SuccessResult(Messages.Rental.Update());
            }
            return new ErrorResult(Messages.NotFound());
        }

        // Business Rules

    }
}
