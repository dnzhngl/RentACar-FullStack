using CarRental.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Abstract
{
    public interface ICarTypeService
    {
        IDataResult<List<CarType>> GetAll();
        IDataResult<CarType> GetById(int carTypeId);
        IDataResult<CarType> GetByName(string carTypeName);
        IResult Add(CarType carType);
        IResult Delete(CarType carType);
        IResult Update(CarType carType);
    }
}
