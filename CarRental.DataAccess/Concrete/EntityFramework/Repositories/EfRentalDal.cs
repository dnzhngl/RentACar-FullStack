using CarRental.Core.DataAccess.EntityFramework;
using CarRental.DataAccess.Abstract;
using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CarRental.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalContext>, IRentalDal
    {
        /// <summary>
        /// Gets all of the rentals details with the customer information, if any lambda expression given, filters the data accordingly.
        /// </summary>
        /// <param name="filter">Lambda expression for filtering the data. It is null by default.</param>
        /// <returns>Returns list of RentalDetailDto.</returns>
        public List<RentalDetailDto> GetAllRentalsDetails(Expression<Func<Rental, bool>> filter =null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from r in (filter == null? context.Rentals : context.Rentals.Where(filter))
                             join car in context.Cars on r.CarId equals car.Id
                             join customer in context.IndividualCustomers on r.CustomerId equals customer.Id
                             join b in context.Brands on car.BrandId equals b.Id
                             join color in context.Colors on car.ColorId equals color.Id
                             join ct in context.CarTypes on car.CarTypeId equals ct.Id
                             select new RentalDetailDto
                             {
                                 Id = r.Id,
                                 CustomerId = customer.Id,
                                 CustomerName = $"{customer.FirstName} {customer.LastName}",
                                 CarId = car.Id,
                                 Brand = b.Name,
                                 Model = car.Model,
                                 Color = color.Name,
                                 CarType = ct.Name,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 Discount = r.Discount,
                                 TotalPrice = r.TotalPrice
                             };
                return result.ToList();

            }
        }


        /// <summary>
        /// Gets the rental detail that has the given id, with the customer information.
        /// </summary>
        /// <returns>Returns an object of RentalDetailDto.</returns>
        public RentalDetailDto GetRentalDetails(int rentalId)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from r in context.Rentals
                             join car in context.Cars on r.CarId equals car.Id
                             join customer in context.IndividualCustomers on r.CustomerId equals customer.Id
                             join b in context.Brands on car.BrandId equals b.Id
                             join color in context.Colors on car.ColorId equals color.Id
                             join ct in context.CarTypes on car.CarTypeId equals ct.Id
                             where r.Id == rentalId
                             select new RentalDetailDto
                             {
                                 Id = r.Id,
                                 CustomerId = customer.Id,
                                 CustomerName = $"{customer.FirstName} {customer.LastName}",
                                 CarId = car.Id,
                                 Brand = b.Name,
                                 Model = car.Model,
                                 Color = color.Name,
                                 CarType = ct.Name,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 Discount = r.Discount,
                                 TotalPrice = r.TotalPrice
                             };
                return result.SingleOrDefault();
            }
        }
    }
}
