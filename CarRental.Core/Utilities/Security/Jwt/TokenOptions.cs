using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Core.Utilities.Security.Jwt
{
    /// <summary>
    /// Holds token standards. 
    /// Has been created to map the TokenOptions that is located into the appsetting.json (configurations) in the WebApi layer.
    /// </summary>
    public class TokenOptions
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int AccessTokenExpiration { get; set; } // minute
        public string SecurityKey { get; set; }
    }
}
