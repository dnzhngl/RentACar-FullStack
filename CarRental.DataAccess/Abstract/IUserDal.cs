using CarRental.Core.DataAccess;
using CarRental.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        /// <summary>
        /// Gets the given user's  operation claims.
        /// </summary>
        /// <param name="user">User object of type User</param>
        /// <returns>Returns list of operation claims of the given user.</returns>
        List<OperationClaim> GetClaims(User user);
    }
}
