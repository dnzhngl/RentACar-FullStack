using AutoMapper;
using CarRental.Business.Abstract;
using CarRental.Business.BusinessAspect;
using CarRental.Business.Constants;
using CarRental.Business.ValidationRules.FluentValidation;
using CarRental.Core.Aspects.Autofac.Caching;
using CarRental.Core.Aspects.Autofac.Performance;
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
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;
        private readonly IMapper _mapper;

        public CarManager(ICarDal carDal, IMapper mapper = null)
        {
            _carDal = carDal;
            _mapper = mapper;
        }

        [SecuredOperation("admin,car.add")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(CarDetailsWithImagesDto carDto)
        {
            var car = _mapper.Map<Car>(carDto);
            _carDal.Add(car);
            return new SuccessResult(Messages.Car.Add(carDto.Model, carDto.ModelYear));
        }

        [SecuredOperation("admin,car.delete")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(CarDetailsWithImagesDto carDto)
        {
            var result = _carDal.Get(c => c.Id == carDto.Id);
            if (result != null)
            {
                var car = _mapper.Map<Car>(carDto);
                _carDal.Delete(car);
                return new SuccessResult(Messages.Car.Delete(result.Model, result.ModelYear));
            }
            return new ErrorResult(Messages.Error());
        }

        [CacheAspect]
        public IDataResult<CarDetailsWithImagesDto> GetById(int carId)
        {
            var result = _carDal.GetCarDetailsWithImagesByCarId(carId);
            if (result != null)
            {
                return new SuccessDataResult<CarDetailsWithImagesDto>(result);
            }
            return new ErrorDataResult<CarDetailsWithImagesDto>(Messages.NotFound());
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<Car>> GetAll()
        {
            var result = _carDal.Count();
            if (result == 0)
            {
                return new ErrorDataResult<List<Car>>(Messages.NotFound());
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        [SecuredOperation("admin,car.update")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(CarDetailsWithImagesDto carDto)
        {
            var result = _carDal.Get(c => c.Id == carDto.Id);
            if (result != null)
            {
                var car = _mapper.Map<Car>(carDto);
                _carDal.Update(car);
                return new SuccessResult(Messages.Car.Update(result.Model, result.ModelYear));
            }
            return new ErrorResult(Messages.Error());
        }

        [PerformanceAspect(5)]
        public IDataResult<List<CarDetailDto>> GetAllCarsDetails()
        {
            var result = _carDal.Any();
            if (!result)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.NotFound());
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarsDetails());
        }


        public IDataResult<List<CarDetailsWithImagesDto>> GetAllCarsDetailByBrandId(int brandId)
        {
            var result = _carDal.Any(c => c.BrandId == brandId);
            if (!result)
            {
                return new ErrorDataResult<List<CarDetailsWithImagesDto>>(Messages.NotFound());
            }
            else if(result)
            {
                return new SuccessDataResult<List<CarDetailsWithImagesDto>>(_carDal.GetCarsDetailsWithImages(c => c.BrandId == brandId));
            }
            return new ErrorDataResult<List<CarDetailsWithImagesDto>>(Messages.Error());
        }

        public IDataResult<List<CarDetailsWithImagesDto>> GetAllCarsDetailByColorId(int colorId)
        {
            var result = _carDal.Any(c => c.BrandId == colorId);
            if (!result)
            {
                return new ErrorDataResult<List<CarDetailsWithImagesDto>>(Messages.NotFound());
            }
            else if (result)
            {
                return new SuccessDataResult<List<CarDetailsWithImagesDto>>(_carDal.GetCarsDetailsWithImages(c => c.ColorId == colorId));
            }
            return new ErrorDataResult<List<CarDetailsWithImagesDto>>(Messages.Error());
        }

        public IDataResult<List<CarDetailsWithImagesDto>> GetAllCarsDetailByCarTypeId(int carTypeId)
        {
            var result = _carDal.Any(c => c.CarTypeId == carTypeId);
            if (!result)
            {
                return new ErrorDataResult<List<CarDetailsWithImagesDto>>(Messages.NotFound());
            }
            else if (result)
            {
                return new SuccessDataResult<List<CarDetailsWithImagesDto>>(_carDal.GetCarsDetailsWithImages(c => c.ColorId == carTypeId));
            }
            return new ErrorDataResult<List<CarDetailsWithImagesDto>>(Messages.Error()); 
        }

        public IDataResult<List<CarDetailsWithImagesDto>> GetCarsDetailsWithImages()
        {
            var result = _carDal.Any();
            if (!result)
            {
                return new ErrorDataResult<List<CarDetailsWithImagesDto>>(Messages.NotFound());
            }
            else if (result)
            {
                return new SuccessDataResult<List<CarDetailsWithImagesDto>>(_carDal.GetCarsDetailsWithImages());
            }
            return new ErrorDataResult<List<CarDetailsWithImagesDto>>(Messages.Error()); 
        }


        public IDataResult<List<CarDetailsWithImagesDto>> GetAllAvailableCarsDetails(DateTime rentDate, DateTime? returnDate)
        {
            //var result = _carDal.GetCarsWithRentals(r => !(r.RentDate >= rentDate && r.ReturnDate <= returnDate));
            var result = _carDal.GetAvailableCarsBetweenDates(rentDate, returnDate);
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<CarDetailsWithImagesDto>>(Messages.NotFound());
            }
            return new SuccessDataResult<List<CarDetailsWithImagesDto>>(result);
        }

    }
}
