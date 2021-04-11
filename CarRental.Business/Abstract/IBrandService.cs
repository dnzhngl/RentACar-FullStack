using CarRental.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Abstract
{
    public interface IBrandService
    {

        IDataResult<List<Brand>> GetAll();

        IDataResult<Brand> GetById(int brandId);

        IDataResult<Brand> GetByName(string brandName);

        IResult Add(Brand brand);

        IResult Delete(Brand brand);

        IResult Update(Brand brand);
    }
}
