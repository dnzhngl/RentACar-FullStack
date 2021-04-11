using CarRental.DataAccess.Abstract;
using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CarRental.DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal /*: ICarDal*/
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                //new Car {Id=1, BrandId=1, CarTypeId=2, ColorId=1, Capacity=4, Model="C 180", ModelYear="2000", DailyPrice=100, Description="4 kişilik, mercedes marka, 2000 model, sedan araba"},
                //new Car {Id=2, BrandId=2, CarTypeId=1, ColorId=1, Capacity=4, Model="Fiesta", ModelYear="2010", DailyPrice=110, Description="4 kişilik, Ford marka, 2010 model, hatchback araba"},
                //new Car {Id=3, BrandId=3, CarTypeId=1, ColorId=1, Capacity=4, Model="Auris", ModelYear="1995", DailyPrice=70, Description="4 kişilik, Toyota marka, 1995 model, hatchback araba"},
                //new Car {Id=4, BrandId=4, CarTypeId=2, ColorId=1, Capacity=4, Model="Astra", ModelYear="2012", DailyPrice=90, Description="4 kişilik, Opel marka, 2012 model, sedan araba"}
            };
        }
        #region Before Generic Repository Implementation
        //public List<Car> GetAll()
        //{
        //    return _cars;
        //}
        //public List<Car> GetAllByBrand(int brandId)
        //{
        //    return _cars.Where(v => v.BrandId == brandId).ToList();
        //}

        //public List<Car> GetAllByCarType(int carTypeId)
        //{
        //    return _cars.Where(v => v.CarTypeId == carTypeId).ToList();
        //}

        //public Car GetById(int carId)
        //{
        //    return _cars.SingleOrDefault(v => v.Id == carId);
        //} 
        #endregion

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            var carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            var query = filter.Compile();
            return (Car)_cars.SingleOrDefault(query.Invoke);
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            if (filter == null)
            {
                return _cars;
            }
            else
            {
                var query = filter.Compile();
                return _cars.Where(query.Invoke).ToList();
            }
        }

        public List<CarDetailDto> GetAllCarsDetailByBrandId(int brandId)
        {
            throw new NotImplementedException();
        }

        public CarDetailDto GetCarDetail(int carId)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarsDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            var carToUpdate = _cars.SingleOrDefault(v => v.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.CarTypeId = car.CarTypeId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.Capacity = car.Capacity;
            carToUpdate.Model = car.Model;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
