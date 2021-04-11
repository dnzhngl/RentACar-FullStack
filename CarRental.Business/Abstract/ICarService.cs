using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();

        /// <summary>
        /// Gets the car that has tha given car id.
        /// </summary>
        /// <param name="carId">Car type id must be given in type of int.</param>
        /// <returns>Returns CarDetailDto object.</returns>
        IDataResult<CarDetailsWithImagesDto> GetById(int carId);
        IResult Add(CarDetailsWithImagesDto carDto);
        IResult Delete(CarDetailsWithImagesDto carDto);
        IResult Update(CarDetailsWithImagesDto carDto);


        /// <summary>
        /// Gets all of the cars with detail information.
        /// </summary>
        /// <returns>Returns list of CarDetailDto object.</returns>
        IDataResult<List<CarDetailDto>> GetAllCarsDetails();

        /// <summary>
        /// Gets all of the cars with detail information that has the given brand id.
        /// </summary>
        /// <param name="brandId">Brand id must be given of type integer.</param>
        /// <returns>Return list of CarDetailsWithImagesDto.</returns>
        IDataResult<List<CarDetailsWithImagesDto>> GetAllCarsDetailByBrandId(int brandId);
        /// <summary>
        /// Gets all of the cars that has the given color Id.
        /// </summary>
        /// <param name="colorId">Color id must be given in type of int.</param>
        /// <returns>Returns list of CarDetailsWithImagesDto object.</returns>
        IDataResult<List<CarDetailsWithImagesDto>> GetAllCarsDetailByColorId(int colorId);

        /// <summary>
        /// Gets all of the cars that has tha given car type Id.
        /// </summary>
        /// <param name="carTypeId">Car type id must be given in type of int.</param>
        /// <returns>Returns list of CarDetailsWithImagesDto object.</returns>
        IDataResult<List<CarDetailsWithImagesDto>> GetAllCarsDetailByCarTypeId(int carTypeId);

        /// <summary>
        /// Gets all of the cars with detail information and with images.
        /// </summary>
        /// <returns>Returns list of CarDetailsWithImagesDto object.</returns>
        IDataResult<List<CarDetailsWithImagesDto>> GetCarsDetailsWithImages();


        /// <summary>
        /// Gets Cars that are available between given days.
        /// </summary>
        /// <param name="rentDate">Start date must be given.</param>
        /// <param name="returnDate">It is nullable.</param>
        /// <returns>Returns lit of cars with their images.</returns>
        IDataResult<List<CarDetailsWithImagesDto>> GetAllAvailableCarsDetails(DateTime rentDate, DateTime? returnDate);

    }
}
