using CarRental.Core.Entities.Concrete;
using CarRental.Core.Utilities.Security.Jwt;
using CarRental.Entities.DTOs;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Abstract
{
    public interface IAuthService
    {
        /// <summary>
        /// Registers the user. Generates hashed and salted versions of user's password and register the user.
        /// </summary>
        /// <param name="userForRegisterDto"></param>
        /// <param name="password"></param>
        /// <returns>Return success with the registered user.</returns>
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        /// <summary>
        /// Checks for the user data. If the given user information are not foud, it returns not found error. If found any matching data of the user, it checks for the password. If it the user's password is true, it returns success result. Else, it returns password error.
        /// </summary>
        /// <param name="userForLoginDto"></param>
        /// <returns></returns>
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        /// <summary>
        /// Checks for the user that has the given email.
        /// </summary>
        /// <param name="email">User's email in a string type.</param>
        /// <returns>If found a matching user with the given email returns error result with an error message else, returns empty success result.</returns>
        IResult UserExists(string email);
        /// <summary>
        /// Checks for the user's claims, and creates access token.
        /// </summary>
        /// <param name="user">User type of user entity.</param>
        /// <returns>If claims of the current user are true, it returns created access token else returns error data result with a message.</returns>
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
