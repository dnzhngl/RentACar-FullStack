using CarRental.DataAccess.Abstract;
using CarRental.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CarRental.DataAccess.Concrete.InMemory
{
    public class InMemoryBrandDal /*: IBrandDal*/
    {
        List<Brand> _brands;
        public InMemoryBrandDal()
        {
            _brands = new List<Brand>
            {
                new Brand{Id=1, Name="Mercedes"},
                new Brand{Id=2, Name="Ford"},
                new Brand{Id=3, Name="Toyota"},
                new Brand{Id=4, Name="Opel"},
                new Brand{Id=5, Name="BMW"},
                new Brand{Id=6, Name="Audi"},
                new Brand{Id=7, Name="Honda"},
            };
        }
        public void Add(Brand brand)
        {
            _brands.Add(brand);
        }

        public void Delete(Brand brand)
        {
            var brandToDelete = _brands.SingleOrDefault(b => b.Id == brand.Id);
            _brands.Remove(brandToDelete);
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            var query = filter.Compile();
            return _brands.SingleOrDefault(query.Invoke);
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            if (filter == null)
            {
                return _brands;
            }
            else
            {
                var query = filter.Compile();
                return _brands.Where(query.Invoke).ToList();
            }
        }

        public void Update(Brand brand)
        {
            var brandToUpdate = _brands.SingleOrDefault(b => b.Id == brand.Id);
            brandToUpdate.Name = brand.Name;
        }
    }
}
