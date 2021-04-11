using CarRental.Core.Entities.Concrete;
using CarRental.Core.Extensions;
using CarRental.Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace CarRental.Core.Utilities.Security.Jwt
{
    /// <summary>
    /// Json Web Token Helper.
    /// </summary>
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }
        private TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;

        /// <summary>
        /// Reads the configuration file at the startup project. Maps the TokenOption section from the configuration file, to the TokenOptions object.
        /// </summary>
        /// <param name="configuration"></param>
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }

        /// <summary>
        /// Creates token for the given user.
        /// The token that is created involves the given list of operation claims the user already has.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="operationClaims"></param>
        /// <returns>Returns access token object.</returns>
        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);

            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt); // writes the jwt token with JwtSecurityTokenHandler

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };
        }

        /// <summary>
        /// Creates Jwt Security token with the given token options, user, signing credentials and operation claims of the user.
        /// </summary>
        /// <param name="tokenOptions">TokenOptions type obbject</param>
        /// <param name="user">User type object</param>
        /// <param name="signingCredentials">SigningCredentials object</param>
        /// <param name="operationClaims">List of operation claims</param>
        /// <returns>Returns jwt securit token.</returns>
        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
           SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,  // if the expiration date is before the current time, it will not be a valid token.
                claims: SetClaims(user, operationClaims),  
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        /// <summary>
        /// Sets claims of the user based on the given user and operation claims of  the user.
        /// </summary>
        /// <param name="user">User of type User</param>
        /// <param name="operationClaims">List of Operation Claims type of OperationClaim</param>
        /// <returns>Return enumerable claims.</returns>
        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            //claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddName(user.UserName);
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());

            return claims;

            //claims.Add(new Claim("email", user.Email)); --> instead of using this, claim class has been extended.
        }

    }
}
