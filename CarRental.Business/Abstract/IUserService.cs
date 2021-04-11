using CarRental.Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int userId);
        IDataResult<User> GetByEmail(string userEmail);
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);

        /// <summary>
        /// Get operation claims of the given user.
        /// </summary>
        /// <param name="user"></param>
        /// <returns>If found any, it returns SuccessResult with the list of operation claims, else returns ErrorResult with an authorization denied message.</returns>
        IDataResult<List<OperationClaim>> GetClaims(User user);

    }
}
