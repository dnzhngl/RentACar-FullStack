using CarRental.Business.Abstract;
using CarRental.Business.BusinessAspect;
using CarRental.Business.Constants;
using CarRental.Business.ValidationRules.FluentValidation;
using CarRental.Core.Aspects.Autofac.Caching;
using CarRental.Core.Aspects.Autofac.Validation;
using CarRental.DataAccess.Abstract;
using CarRental.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Concrete
{
    public class CarTypeManager : ICarTypeService
    {
        private readonly ICarTypeDal _carTypeDal;
        public CarTypeManager(ICarTypeDal carTypeDal)
        {
            _carTypeDal = carTypeDal;
        }

        [SecuredOperation("admin,carType.add")]
        [ValidationAspect(typeof(CarTypeValidator))]
        [CacheRemoveAspect("ICarTypeService.Get")]
        public IResult Add(CarType carType)
        {
            var result = _carTypeDal.Any(c => c.Name == carType.Name);
            if (!result)
            {
                _carTypeDal.Add(carType);
                return new SuccessResult(Messages.CarType.Add(carType.Name));
            }
            return new ErrorResult(Messages.CarType.Exists(carType.Name));
        }

        [SecuredOperation("admin,carType.delete")]
        [CacheRemoveAspect("ICarTypeService.Get")]
        public IResult Delete(CarType carType)
        {
            var result = _carTypeDal.Any(c => c.Id == carType.Id);
            if (result)
            {
                _carTypeDal.Delete(carType);
                return new SuccessResult(Messages.CarType.Delete(carType.Name));
            }
            return new ErrorResult(Messages.Error());
        }

        public IDataResult<CarType> GetById(int carTypeId)
        {
            var result = _carTypeDal.Any(c => c.Id == carTypeId);
            if (result)
            {
                return new SuccessDataResult<CarType>(_carTypeDal.Get(vt => vt.Id == carTypeId));
            }
            return new ErrorDataResult<CarType>(Messages.NotFound());
        }

        [CacheAspect]
        public IDataResult<List<CarType>> GetAll()
        {
            var result = _carTypeDal.Count();
            if (result > 0)
            {
                return new SuccessDataResult<List<CarType>>(_carTypeDal.GetAll());
            }
            return new ErrorDataResult<List<CarType>>(Messages.NotFound());
        }

        [SecuredOperation("admin,carType.update")]
        [ValidationAspect(typeof(CarTypeValidator))]
        [CacheRemoveAspect("ICarTypeService.Get")]
        public IResult Update(CarType carType)
        {
            var result = _carTypeDal.Any(c => c.Id == carType.Id);
            if (result)
            {
                _carTypeDal.Update(carType);
                return new SuccessResult(Messages.CarType.Update(carType.Name));
            }
            return new ErrorResult(Messages.Error());
        }

        public IDataResult<CarType> GetByName(string carTypeName)
        {
            var result = _carTypeDal.Any(c => c.Name == carTypeName);
            if (result)
            {
                return new SuccessDataResult<CarType>(_carTypeDal.Get(vt => vt.Name == carTypeName));
            }
            return new ErrorDataResult<CarType>(Messages.NotFound());
        }
    }
}
