using CarRental.Business.Abstract;
using CarRental.Business.Constants;
using CarRental.Core.Entities.Concrete;
using CarRental.Core.Utilities.Security.Hashing;
using CarRental.Core.Utilities.Security.Jwt;
using CarRental.Entities.DTOs;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        /// <summary>
        /// Checks for the user's claims, and creates access token.
        /// </summary>
        /// <param name="user">User type of user entity.</param>
        /// <returns>If claims of the current user are true, it returns created access token else returns error data result with a message.</returns>
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            if (claims.Success)
            {
                var accessToken = _tokenHelper.CreateToken(user, claims.Data);
                return new SuccessDataResult<AccessToken>(accessToken, Messages.Authentication.AccessTokenCreated);
            }
            return new ErrorDataResult<AccessToken>(claims.Message);
        }

        /// <summary>
        /// Checks for the user data. If the given user information are not foud, it returns not found error. If found any matching data of the user, it checks for the password. If it the user's password is true, it returns success result. Else, it returns password error.
        /// </summary>
        /// <param name="userForLoginDto"></param>
        /// <returns></returns>
        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByEmail(userForLoginDto.Email);
            if (userToCheck.Data == null)
            {
                return new ErrorDataResult<User>(Messages.User.NotFound());
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.Authentication.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck.Data, Messages.Authentication.SuccessfulLogin);
        }

        /// <summary>
        /// Registers the user. Generates hashed and salted versions of user's password and register the user.
        /// </summary>
        /// <param name="userForRegisterDto"></param>
        /// <param name="password"></param>
        /// <returns>Return success with the registered user.</returns>
        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            
            var user = new User
            {
                UserName = userForRegisterDto.UserName,
                Email = userForRegisterDto.Email,
                //FirstName = userForRegisterDto.FirstName,
                //LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true,
                JoinDate = DateTime.Now
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.Authentication.UserRegistered);
        }

        /// <summary>
        /// Checks for the user that has the given email.
        /// </summary>
        /// <param name="email">User's email in a string type.</param>
        /// <returns>If found a matching user with the given email returns error result with an error message else, returns empty success result.</returns>
        public IResult UserExists(string email)
        {
            if (_userService.GetByEmail(email).Data != null)
            {
                return new ErrorResult(Messages.Authentication.UserAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
