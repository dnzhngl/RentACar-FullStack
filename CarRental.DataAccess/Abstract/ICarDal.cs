using CarRental.Core.DataAccess;
using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CarRental.DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        
        /// <summary>
        /// Gets detailed information of the car that has the given id.
        /// </summary>
        /// <param name="carId">Car id must be given.</param>
        /// <returns>Return CarDetailDto that contains car's information with the brand, color and car type data.</returns>
        CarDetailDto GetCarDetail(int carId);

        /// <summary>
        /// Gets detailed information of all the cars that has passed the given filter.
        /// </summary>
        /// <param name="filter">Filter must be given as lambda expression.</param>
        /// <returns></returns>
        List<CarDetailDto> GetCarsDetails(Expression<Func<Car, bool>> filter = null);
        /// <summary>
        /// Gets list of ca details with their images.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        List<CarDetailsWithImagesDto> GetCarsDetailsWithImages(Expression<Func<Car, bool>> filter = null);

        /// <summary>
        /// Gets Car's details with its images paths as a string array list.
        /// </summary>
        /// <param name="carId">Car id must be given.</param>
        /// <returns></returns>
        CarDetailsWithImagesDto GetCarDetailsWithImagesByCarId(int carId);

        /// <summary>
        /// Gets Cars that are available between given days.
        /// </summary>
        /// <param name="rentDate">Start date must be given.</param>
        /// <param name="returnDate">It is nullable.</param>
        /// <returns>Returns lit of cars with their images.</returns>
        List<CarDetailsWithImagesDto> GetAvailableCarsBetweenDates(DateTime rentDate, DateTime? returnDate);
    }
}
