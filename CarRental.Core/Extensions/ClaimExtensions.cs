using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace CarRental.Core.Extensions
{
    public static class ClaimExtensions
    {
        /// <summary>
        /// Adds claims of the user, the user's email.
        /// </summary>
        /// <param name="claims"></param>
        /// <param name="email">Email address of type string.</param>
        public static void AddEmail(this ICollection<Claim> claims, string email)
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, email));
        }
        /// <summary>
        /// Adds claims of the user, the user's name.
        /// </summary>
        /// <param name="claims"></param>
        /// <param name="name">Name of type string.</param>
        public static void AddName(this ICollection<Claim> claims, string name)
        {
            claims.Add(new Claim(ClaimTypes.Name, name));
        }
        /// <summary>
        /// Adds claims of the user, the user's name identifier.
        /// </summary>
        /// <param name="claims"></param>
        /// <param name="nameIdentifier">Nameidentifier of type string.</param>
        public static void AddNameIdentifier(this ICollection<Claim> claims, string nameIdentifier)
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, nameIdentifier));
        }
        /// <summary>
        /// Adds claims of the user, the user's list of roles.
        /// </summary>
        /// <param name="claims"></param>
        /// <param name="roles">Array of roles of type string.</param>
        public static void AddRoles(this ICollection<Claim> claims, string[] roles)
        {
            roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
        }
    }
}
