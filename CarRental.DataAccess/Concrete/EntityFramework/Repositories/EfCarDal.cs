using CarRental.Core.DataAccess.EntityFramework;
using CarRental.DataAccess.Abstract;
using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CarRental.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        /// <summary>
        /// Gets detailed information of the car that has the given id.
        /// </summary>
        /// <param name="carId">Car id must be given.</param>
        /// <returns>Returns CarDetailDto that contains car's information with the brand, color and car type data.</returns>
        public CarDetailDto GetCarDetail(int carId)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in context.Cars
                             join ct in context.CarTypes on c.CarTypeId equals ct.Id
                             join b in context.Brands on c.BrandId equals b.Id
                             join cl in context.Colors on c.ColorId equals cl.Id
                             where c.Id == carId
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 Brand = b.Name,
                                 Color = cl.Name,
                                 CarType = ct.Name,
                                 Model = c.Model,
                                 ModelYear = c.ModelYear,
                                 Capacity = c.Capacity,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 IsAvailable = c.IsAvailable
                             };
                return result.FirstOrDefault();
            }
        }

        /// <summary>
        /// Gets detailed information of all the cars that has passed the given filter.
        /// </summary>
        /// <param name="filter">Filter must be given as lambda expression.</param>
        /// <returns></returns>
        public List<CarDetailDto> GetCarsDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in (filter == null ? context.Cars : context.Cars.Where(filter))
                             join ct in context.CarTypes on c.CarTypeId equals ct.Id
                             join b in context.Brands on c.BrandId equals b.Id
                             join cl in context.Colors on c.ColorId equals cl.Id
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 Brand = b.Name,
                                 Color = cl.Name,
                                 CarType = ct.Name,
                                 Model = c.Model,
                                 ModelYear = c.ModelYear,
                                 Capacity = c.Capacity,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 IsAvailable = c.IsAvailable
                             };
                return result.ToList();
            }
        }

        public List<CarDetailsWithImagesDto> GetCarsDetailsWithImages(Expression<Func<Car, bool>> filter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in (filter == null ? context.Cars : context.Cars.Where(filter))
                             join ct in context.CarTypes on c.CarTypeId equals ct.Id
                             join b in context.Brands on c.BrandId equals b.Id
                             join cl in context.Colors on c.ColorId equals cl.Id
                             select new CarDetailsWithImagesDto
                             {
                                 Id = c.Id,
                                 Brand = b.Name,
                                 Color = cl.Name,
                                 CarType = ct.Name,

                                 BrandId = b.Id,
                                 CarTypeId = ct.Id,
                                 ColorId = cl.Id,

                                 Model = c.Model,
                                 ModelYear = c.ModelYear,
                                 Capacity = c.Capacity,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 IsAvailable = c.IsAvailable,
                                 Images = (from image in context.CarImages
                                           where image.CarId == c.Id
                                           select new CarImageDto
                                           {
                                               Id = image.Id,
                                               CarId = image.CarId,
                                               ImagePath = image.ImagePath
                                           }).ToList()
                             };
                return result.ToList();
            }
        }        
        
        
        public CarDetailsWithImagesDto GetCarDetailsWithImagesByCarId(int carId)
        {
            using (CarRentalContext context = new CarRentalContext())
            {


                var result = from c in context.Cars
                             join ct in context.CarTypes on c.CarTypeId equals ct.Id
                             join b in context.Brands on c.BrandId equals b.Id
                             join cl in context.Colors on c.ColorId equals cl.Id
                             where c.Id == carId
                             select new CarDetailsWithImagesDto
                             {
                                 Id = c.Id,
                                 Brand = b.Name,
                                 Color = cl.Name,
                                 CarType = ct.Name,

                                 BrandId = b.Id,
                                 CarTypeId = ct.Id,
                                 ColorId = cl.Id,

                                 Model = c.Model,
                                 ModelYear = c.ModelYear,
                                 Capacity = c.Capacity,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 IsAvailable = c.IsAvailable,
                                 Images = (from image in context.CarImages
                                           where image.CarId == c.Id
                                           select new CarImageDto
                                           {
                                               Id = image.Id,
                                               CarId = image.CarId,
                                               ImagePath = image.ImagePath
                                           }).ToList()
                             };
                return result.SingleOrDefault();
            }
        }

        /// <summary>
        /// Gets Cars that are available between given days.
        /// </summary>
        /// <param name="rentDate">Start date must be given.</param>
        /// <param name="returnDate">It is nullable.</param>
        /// <returns>Returns lit of cars with their images.</returns>
        public List<CarDetailsWithImagesDto> GetAvailableCarsBetweenDates(DateTime rentDate, DateTime? returnDate)
        {
            //cr.RentDate > returnDate && rentDate > cr.ReturnDate

            using (CarRentalContext context = new CarRentalContext())
            {

                //var cars = from c in context.Cars
                //       where !(from car in context.Cars
                //               join r in context.Rentals on car.Id equals r.CarId
                //               where returnDate == null ? 
                //                   (r.ReturnDate == null || r.ReturnDate >= rentDate) : 
                //                   (r.ReturnDate == null && r.RentDate <= returnDate) || (r.RentDate <= returnDate && r.ReturnDate >= rentDate)
                //               select car.Id).Contains(c.Id)
                //       select c;

                var result = from c in //cars
                                (from c in context.Cars
                                 where !(from car in context.Cars
                                         join r in context.Rentals on car.Id equals r.CarId
                                         where returnDate == null ?
                                             (r.ReturnDate == null || r.ReturnDate >= rentDate) :
                                             (r.ReturnDate == null && r.RentDate <= returnDate) || (r.RentDate <= returnDate && r.ReturnDate >= rentDate)
                                         select car.Id).Contains(c.Id) // Gets cars that are not available between given dates
                                 select c) // Get cars from cars table that are available (converts the inner query)
                             join ct in context.CarTypes on c.CarTypeId equals ct.Id
                             join b in context.Brands on c.BrandId equals b.Id
                             join cl in context.Colors on c.ColorId equals cl.Id
                             select new CarDetailsWithImagesDto
                             {
                                 Id = c.Id,
                                 Brand = b.Name,
                                 Color = cl.Name,
                                 CarType = ct.Name,

                                 BrandId = b.Id,
                                 CarTypeId = ct.Id,
                                 ColorId = cl.Id,

                                 Model = c.Model,
                                 ModelYear = c.ModelYear,
                                 Capacity = c.Capacity,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,

                                 IsAvailable = c.IsAvailable,
                                 Images = (from image in context.CarImages
                                           where image.CarId == c.Id
                                           select new CarImageDto
                                           {
                                               Id = image.Id,
                                               CarId = image.CarId,
                                               ImagePath = image.ImagePath
                                           }).ToList()
                             };

                return result.ToList();
            }
        }
    }
}
