using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetById(int rentalId);
        IResult Add(RentalDetailDto rental);
        IResult Delete(RentalDetailDto rentalDto);
        IResult Update(RentalDetailDto rental);

        /// <summary>
        /// Gets rental details that has the given rentalId.
        /// </summary>
        /// <param name="rentalId">Rental id must be given of type integer.</param>
        /// <returns>Returns SuccessDataResult with data of type RentalDetailDto if found any, else returns ErrorDataResult with an error message.</returns>
        IDataResult<RentalDetailDto> GetRentalDetails(int rentalId);
        /// <summary>
        /// Get rentals detailed information.
        /// </summary>
        /// <returns>If founds any, returns SuccessDataResult with a list of RentalDetailDto, else return ErrorDataResult with an error message.</returns>
        IDataResult<List<RentalDetailDto>> GetAllRentalsDetails();
        /// <summary>
        /// Get rentals detailed information that are not returned yet.
        /// </summary>
        /// <returns>If founds any, returns SuccessDataResult with a list of RentalDetailDto, else return ErrorDataResult with an error message.</returns>
        IDataResult<List<RentalDetailDto>> GetAllNotReturnedRentalsDetails();
    }
}
