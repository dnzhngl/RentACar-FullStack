using CarRental.DataAccess.Abstract;
using CarRental.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CarRental.DataAccess.Concrete.InMemory
{
    public class InMemoryRentalDal /*: IRentalDal*/
    {
        List<Rental> _rentals;
        public InMemoryRentalDal()
        {
            _rentals = new List<Rental>();
        }

        #region Before Generic Repository Implementation
        //public List<Rental> GetAll()
        //{
        //    return _rentals;
        //}
        //public List<Rental> GetAllByCustomer(int customerId)
        //{
        //    return _rentals.Where(a => a.CustomerId == customerId).ToList();
        //}

        //public List<Rental> GetAllByEmployee(int employeeId)
        //{
        //    return _rentals.Where(a => a.EmployeeId == employeeId).ToList();
        //}

        //public Rental GetById(int RentalId)
        //{
        //    return _rentals.SingleOrDefault(a => a.Id == RentalId);
        //} 
        #endregion

        public void Add(Rental Rental)
        {
            _rentals.Add(Rental);
        }

        public void Delete(Rental Rental)
        {
            var agreementToDelete = _rentals.SingleOrDefault(a => a.Id == Rental.Id);
            _rentals.Remove(agreementToDelete);
        }

        public Rental Get(Expression<Func<Rental, bool>> filter)
        {
            var query = filter.Compile();
            return (Rental)_rentals.SingleOrDefault(query.Invoke);
        }

        public List<Rental> GetAll(Expression<Func<Rental, bool>> filter = null)
        {
            if (filter == null)
            {
                return _rentals;
            }
            else
            {
                var query = filter.Compile();
                return _rentals.Where(query.Invoke).ToList();
            }
        }

        public void Update(Rental Rental)
        {
            var agreementToUpdate = _rentals.SingleOrDefault(a => a.Id == Rental.Id);
            agreementToUpdate.CustomerId = Rental.CustomerId;
            //agreementToUpdate.RentDate = Rental.RentDate;
            //agreementToUpdate.ReturnDate = Rental.ReturnDate;
            agreementToUpdate.TotalPrice = Rental.TotalPrice;
            agreementToUpdate.Discount = Rental.Discount;
        }
    }
}
