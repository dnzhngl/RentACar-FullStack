using CarRental.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Abstract
{
    public interface IColorService
    {
        IDataResult<List<Color>> GetAll();
        IDataResult<Color> GetById(int colorId);
        IDataResult<Color> GetByName(string colorName);
        IResult Add(Color color);
        IResult Delete(Color color);
        IResult Update(Color color);
    }
}
