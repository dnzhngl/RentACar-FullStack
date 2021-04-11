using AutoMapper;
using CarRental.Business.Abstract;
using CarRental.Business.BusinessAspect;
using CarRental.Business.Constants;
using CarRental.Business.ValidationRules.FluentValidation;
using CarRental.Core.Aspects.Autofac.Caching;
using CarRental.Core.Aspects.Autofac.Performance;
using CarRental.Core.Aspects.Autofac.Transaction;
using CarRental.Core.Aspects.Autofac.Validation;
using CarRental.Core.Helpers;
using CarRental.Core.Utilities.Business;
using CarRental.DataAccess.Abstract;
using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private readonly ICarImageDal _carImageDal;
        private readonly IMapper _mapper;
        private readonly int imageLimit = 5;
        public CarImageManager(ICarImageDal carImageDal, IMapper mapper)
        {
            _carImageDal = carImageDal;
            _mapper = mapper;
        }

        [SecuredOperation("admin,carImage.add")]
        [ValidationAspect(typeof(CarImageValidator))]
        [CacheRemoveAspect("ICarImageService.Get")]
        [TransactionScopeAspect]
        public IResult Add(CarImageDto carImageDto)
        {
            var result = BusinessRules.Run(CheckIfImageLimitExceeded(carImageDto.CarId));
            if (result != null) { return result; }

            var isFileUploaded = FileHelper.UploadFile(carImageDto.Image);
            if (!isFileUploaded.Success) { return new ErrorResult(isFileUploaded.Message); }

            var carImage = new CarImage
            {
                CarId = carImageDto.CarId,
                ImagePath = isFileUploaded.Data
            };
            _carImageDal.Add(carImage);

            return new SuccessResult(Messages.CarImage.Add(isPlural: false));
        }

        [SecuredOperation("admin,carImage.add")]
        [ValidationAspect(typeof(CarImageValidator))]
        [CacheRemoveAspect("ICarImageService.Get")]
        [TransactionScopeAspect]
        public IResult AddMultiple(List<CarImageDto> carImageDtos)
        {
            if (carImageDtos.Count == 0) { return new ErrorResult(Messages.Error()); }

            var result = BusinessRules.Run(CheckIfImageLimitExceeded(carImageDtos[0].CarId));
            if (result != null) { return result; }
            foreach (var image in carImageDtos)
            {
                var isFileUploaded = FileHelper.UploadFile(image.Image);
                if (!isFileUploaded.Success) { return new ErrorResult(isFileUploaded.Message); }

                var carImage = _mapper.Map<CarImage>(image);
                _carImageDal.Add(carImage);
            }
            return new SuccessResult(Messages.CarImage.Add(isPlural: true));
        }

        [SecuredOperation("admin,carImage.delete")]
        [CacheRemoveAspect("ICarImageService.Get")]
        [TransactionScopeAspect]
        public IResult Delete(CarImage carImage)
        {
            var result = _carImageDal.Any(c => c.Id == carImage.Id);
            if (!result) { return new ErrorResult(Messages.NotFound()); }

            var isFileDeleted = FileHelper.DeleteFile(carImage.ImagePath);
            if (!isFileDeleted.Success) { return new ErrorResult(isFileDeleted.Message); }

            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImage.Delete(isPlural: false));
        }

        [SecuredOperation("admin,carImage.delete")]
        [CacheRemoveAspect("ICarImageService.Get")]
        [TransactionScopeAspect]
        public IResult DeleteMultiple(List<CarImage> carImages)
        {
            if (carImages.Count == 0) { return new ErrorResult(Messages.Error()); }
            foreach (var image in carImages)
            {
                var isFileDeleted = (ErrorResult)FileHelper.DeleteFile(image.ImagePath);
                if (!isFileDeleted.Success) { return new ErrorResult(isFileDeleted.Message); }

                _carImageDal.Delete(image);
            };
            return new SuccessResult(Messages.CarImage.Delete(isPlural: true));
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<CarImage> GetById(int id)
        {
            var result = _carImageDal.Any(c => c.Id == id);
            if (result)
            {
                return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == id));
            }
            return new ErrorDataResult<CarImage>(Messages.NotFound());
        }


        /// <summary>
        /// Returns all of the images belongs to the car that has the given id. If it is not found any image data for the car, it returns the default picture (company logo).
        /// </summary>
        /// <param name="carId"></param>
        /// <returns></returns>
        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            var result = _carImageDal.Any(c => c.CarId == carId);
            if (result)
            {
                return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
            }
            var defaultImage = AssignDefaultPicture(carId).Data;
            return new SuccessDataResult<List<CarImage>>(defaultImage);
        }

        [SecuredOperation("admin,carImage.update")]
        [ValidationAspect(typeof(CarImageValidator))]
        [CacheRemoveAspect("ICarImageService.Get")]
        [TransactionScopeAspect]
        public IResult Update(CarImageDto carImageDto)
        {
            var result = BusinessRules.Run(CheckIfImageLimitExceeded(5));
            if (result != null) { return result; }

            var isFileUploaded = FileHelper.UpdateFile(carImageDto.Image, carImageDto.ImagePath);
            if (!isFileUploaded.Success) { return new ErrorResult(isFileUploaded.Message); }

            var carImage = new CarImage
            {
                Id = carImageDto.Id,
                CarId = carImageDto.CarId,
                ImagePath = isFileUploaded.Data
            };
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImage.Add(isPlural: false));
        }

        #region Business Codes
        /// <summary>
        /// Check for the number of images that the car with the given carid has. 
        /// </summary>
        /// <param name="carId"></param>
        /// <returns>If number of images is equals to the image limit, it returns error. Else returns succes.</returns>
        private IResult CheckIfImageLimitExceeded(int carId)
        {
            var numberOfImages = _carImageDal.Count(c => c.CarId == carId);
            if (numberOfImages >= imageLimit)
            {
                return new ErrorResult(Messages.CarImage.NumberOfPhotografsHasReachedLimit(5));
            }
            return new SuccessResult();
        }

        /// <summary>
        /// Assigns default image for the cars that has no image data.
        /// It does not update or insert data into the database. This method should only be used in get operations. 
        /// </summary>
        /// <param name="carId"></param>
        /// <returns>Returns car image object with the default image path.</returns>
        private IDataResult<List<CarImage>> AssignDefaultPicture(int carId)
        {
            List<CarImage> imageList = new List<CarImage> {
            new CarImage
            {
                CarId = carId,
                ImagePath = FileHelper.GetLogoPath()
            }};
            return new SuccessDataResult<List<CarImage>>(imageList);
        }
        #endregion
    }
}
