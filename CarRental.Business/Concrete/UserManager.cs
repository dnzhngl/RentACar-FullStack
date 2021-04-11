using CarRental.Business.Abstract;
using CarRental.Business.BusinessAspect;
using CarRental.Business.Constants;
using CarRental.Core.Entities.Concrete;
using CarRental.Core.Utilities.Business;
using CarRental.DataAccess.Abstract;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            var result = _userDal.Any(u => u.Email == user.Email);
            if (result)
            {
                return new ErrorResult(Messages.User.Exists(user.Email));
            }
            _userDal.Add(user);
            return new SuccessResult(Messages.User.Add());
        }

        public IResult Delete(User user)
        {
            var result = _userDal.Any(u => u.Id == user.Id);
            if (!result)
            {
                return new ErrorResult(Messages.NotFound());
            }
            _userDal.Delete(user);
            return new SuccessResult(Messages.User.Delete());
        }
        [SecuredOperation("admin,user.getall")]
        public IDataResult<List<User>> GetAll()
        {
            var result = _userDal.Count();
            if (result == 0)
            {
                return new ErrorDataResult<List<User>>(Messages.NotFound());
            }
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetByEmail(string userEmail)
        {
            var result = _userDal.Any(u => u.Email == userEmail);
            if (!result)
            {
                return new ErrorDataResult<User>(Messages.NotFound());
            }
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == userEmail));
        }

        public IDataResult<User> GetById(int userId)
        {
            var result = _userDal.Any(u => u.Id == userId);
            if (!result)
            {
                return new ErrorDataResult<User>(Messages.NotFound());
            }
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == userId));
        }

        /// <summary>
        /// Get operation claims of the given user.
        /// </summary>
        /// <param name="user"></param>
        /// <returns>If found any, it returns SuccessResult with the list of operation claims, else returns ErrorResult with an authorization denied message.</returns>
        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            var result = _userDal.Any(u => u.Id == user.Id);
            if (!result)
            {
                return new ErrorDataResult<List<OperationClaim>>(Messages.Authorization.AuthorizationDenied());
            }
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IResult Update(User user)
        {
            var result = _userDal.Any(u => u.Id == user.Id);
            if (!result) 
            {
                return new ErrorResult(Messages.NotFound());
            }

            _userDal.Update(user);
            return new SuccessResult(Messages.User.Update());
        }

        //Business Codes

    }
}
