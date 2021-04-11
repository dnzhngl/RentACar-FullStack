using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Core.Utilities.Security.Jwt
{
    /// <summary>
    /// Holds access token information.
    /// Includes Token and Expiration fields.
    /// </summary>
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
