using CarRental.Business.Abstract;
using CarRental.Business.BusinessAspect;
using CarRental.Business.Constants;
using CarRental.Business.ValidationRules.FluentValidation;
using CarRental.Core.Aspects.Autofac.Caching;
using CarRental.Core.Aspects.Autofac.Validation;
using CarRental.DataAccess.Abstract;
using CarRental.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Concrete
{
    public class ColorManager : IColorService
    {
        private readonly IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [SecuredOperation("admin,color.add")]
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            var result = _colorDal.Any(c => c.Name == color.Name);
            if (!result)
            {
                _colorDal.Add(color);
                return new SuccessResult(Messages.Color.Add(color.Name));
            }
            return new ErrorResult(Messages.Color.Exists(color.Name));
        }
        [SecuredOperation("admin,color.delete")]
        public IResult Delete(Color color)
        {
            var result = _colorDal.Get(c => c.Id == color.Id);
            if (result != null)
            {
                _colorDal.Delete(color);
                return new SuccessResult(Messages.Color.Delete(color.Name));
            }
            return new ErrorResult(Messages.NotFound());
        }

        public IDataResult<List<Color>> GetAll()
        {
            var result = _colorDal.Count();
            if (result > 0)
            {
                return new SuccessDataResult<List<Color>>( _colorDal.GetAll());
            }
            return new ErrorDataResult<List<Color>>(Messages.NotFound());
        }

        public IDataResult<Color> GetById(int colorId)
        {
            var result = _colorDal.Any(c => c.Id == colorId);
            if (result)
            {
                return new SuccessDataResult<Color>( _colorDal.Get(c => c.Id == colorId));
            }
            return new ErrorDataResult<Color>(Messages.NotFound());
        }

        public IDataResult<Color> GetByName(string colorName)
        {
            var result = _colorDal.Any(c => c.Name == colorName);
            if (result)
            {
                return new SuccessDataResult<Color>(_colorDal.Get(c => c.Name == colorName));
            }
            return new ErrorDataResult<Color>(Messages.NotFound());
        }

        [SecuredOperation("admin,color.update")]
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Update(Color color)
        {
            var result = _colorDal.Get(c => c.Id == color.Id);
            if (result != null)
            {
                _colorDal.Update(color);
                return new SuccessResult(Messages.Color.Update(color.Name));
            }
            return new ErrorResult(Messages.NotFound());
        }
    }
}
