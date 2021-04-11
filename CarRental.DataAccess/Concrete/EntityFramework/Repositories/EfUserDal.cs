using CarRental.Core.DataAccess.EntityFramework;
using CarRental.Core.Entities.Concrete;
using CarRental.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;

namespace CarRental.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfUserDal : EfEntityRepositoryBase<User, CarRentalContext>, IUserDal
    {
        /// <summary>
        /// Gets the given user's operation claims.
        /// </summary>
        /// <param name="user">User object of type User.</param>
        /// <returns>Returns list of operation claims of the given user.</returns>
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new CarRentalContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim {
                                 Id = operationClaim.Id, 
                                 Name = operationClaim.Name 
                             };
                return result.ToList();
            }
        }
    }
}
