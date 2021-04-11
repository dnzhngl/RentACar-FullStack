
using CarRental.DataAccess.Abstract;
using CarRental.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CarRental.DataAccess.Concrete.InMemory
{
    public class InMemoryCarTypeDal /*: ICarTypeDal*/
    {
        List<CarType> _carTypes;
        public InMemoryCarTypeDal()
        {
            _carTypes = new List<CarType>
            {
                new CarType { Id = 1, Name= "Hatchback"},
                new CarType { Id = 2, Name= "Sedan"},
                new CarType { Id = 3, Name= "SUV"},
                new CarType { Id = 4, Name= "Pickup"},
                new CarType { Id = 5, Name= "Coupe"},
                new CarType { Id = 6, Name= "Minivan"},
                new CarType { Id = 6, Name= "Van"},
                new CarType { Id = 6, Name= "Mini Truck"},
            };
        }
        #region Before Generic Repository implementation
        //public List<CarType> GetAll()
        //{
        //    return _carTypes;
        //}
        //public CarType GetById(int CarTypeId)
        //{
        //    return _carTypes.SingleOrDefault(v => v.Id == CarTypeId);
        //} 
        #endregion
        public void Add(CarType CarType)
        {
            _carTypes.Add(CarType);
        }

        public void Delete(CarType CarType)
        {
            var CarToDelete = _carTypes.SingleOrDefault(v => v.Id == CarType.Id);
            _carTypes.Remove(CarToDelete);
        }

        public CarType Get(Expression<Func<CarType, bool>> filter)
        {
            var query = filter.Compile();
            return (CarType)_carTypes.SingleOrDefault(query.Invoke);
        }

        public List<CarType> GetAll(Expression<Func<CarType, bool>> filter = null)
        {
            if (filter == null)
            {
                return _carTypes;
            }
            else
            {
                var query = filter.Compile();
                return _carTypes.Where(query.Invoke).ToList();
            }
        }

        public void Update(CarType CarType)
        {
            var CarToUpdate = _carTypes.SingleOrDefault(v => v.Id == CarType.Id);
            CarToUpdate.Name = CarType.Name;
        }
    }
}
