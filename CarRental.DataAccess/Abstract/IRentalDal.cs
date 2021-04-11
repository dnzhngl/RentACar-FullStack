using CarRental.Core.DataAccess;
using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CarRental.DataAccess.Abstract
{
    public interface IRentalDal : IEntityRepository<Rental>
    {
        /// <summary>
        /// Gets all of the rentals details with the customer information, if any lambda expression given, filters the data accordingly.
        /// </summary>
        /// <param name="filter">Lambda expression for filtering the data. It is null by default.</param>
        /// <returns>Returns list of RentalDetailDto.</returns>
        List<RentalDetailDto> GetAllRentalsDetails(Expression<Func<Rental, bool>> filter = null);

        /// <summary>
        /// Gets the rental detail that has the given id, with the customer information.
        /// </summary>
        /// <returns>Returns an object of RentalDetailDto.</returns>
        RentalDetailDto GetRentalDetails(int rentalId);

        #region Before Expression function implementation
        /// <summary>
        /// Gets all of the rentals details that are returned with the customer information.
        /// </summary>
        /// <returns>Returns list of RentalDetailDto.</returns>
       // List<RentalDetailDto> GetAllReturnedRentalsDetails();
        /// <summary>
        /// Gets all of the rentals that are not returned yet with the customer data.
        /// </summary>
        /// <returns>Returns list of RentalDetailDto.</returns>
       // List<RentalDetailDto> GetAllNotReturnedRentalsDetails();
        #endregion
    }
}
