using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        /// <summary>
        /// Creates signing credentials.
        /// </summary>
        /// <param name="securityKey"></param>
        /// <returns>Returns SigningCredentials based on the given security key and security algorithm of HmacSha512Signature.</returns>
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
