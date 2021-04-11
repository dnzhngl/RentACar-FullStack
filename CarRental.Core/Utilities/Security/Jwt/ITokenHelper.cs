using CarRental.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Core.Utilities.Security.Jwt
{
    /// <summary>
    /// It can be implemented with different types of token helpers.
    /// </summary>
    public interface ITokenHelper
    {
        /// <summary>
        /// Creates token for the given user.
        /// And roles of the user will be included into the created token.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="operationClaims"></param>
        /// <returns></returns>
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
