using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Abstract
{
    public interface ICarImageService
    {
        /// <summary>
        /// Returns all of the images belongs to the car that has the given id. If it is not found any image data for the car, it returns the default picture (company logo).
        /// </summary>
        /// <param name="carId"></param>
        /// <returns></returns>
        IDataResult<List<CarImage>> GetImagesByCarId(int carId);
        IDataResult<CarImage> GetById(int id);
        IResult Add(CarImageDto carImageDto);
        IResult Delete(CarImage carImage);
        IResult Update(CarImageDto carImageDto);

        /// <summary>
        /// Adds list of images
        /// </summary>
        /// <param name="carImageDtos"></param>
        /// <returns></returns>
        IResult AddMultiple(List<CarImageDto> carImageDtos);
        /// <summary>
        /// Deletes list of images
        /// </summary>
        /// <param name="carImages"></param>
        /// <returns></returns>
        IResult DeleteMultiple(List<CarImage> carImages);
    }
}
