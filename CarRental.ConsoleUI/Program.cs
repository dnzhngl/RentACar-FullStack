using CarRental.Business.Abstract;
using CarRental.Business.Concrete;
using CarRental.DataAccess.Concrete.EntityFramework.Repositories;
using CarRental.DataAccess.Concrete.InMemory;
using CarRental.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRental.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            CarTypeManager carTypeManager = new CarTypeManager(new EfCarTypeDal());

            UserManager userManager = new UserManager(new EfUserDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            IndividualCustomerManager individualCustomerManager = new IndividualCustomerManager(new EfIndividualCustomerDal());
            CorporateCustomerManager corporateCustomerManager = new CorporateCustomerManager(new EfCorporateCustomerDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());


            //AddDefaultData(carManager, brandManager, colorManager, carTypeManager);
            //AddIndividualCustomer(individualCustomerManager);
            //AddCorporateCustomer(corporateCustomerManager);
            //AddRental(carManager, rentalManager);
        }


        #region SeedData

        private static void AddRental(CarManager carManager, RentalManager rentalManager)
        {
            var car1 = carManager.GetById(1).Data;
            // var carList = new List<Car>();
            // carList.Add(car1);

            var agreement = new Rental
            {
                CustomerId = 1,
                CarId = 1,
                RentDate = DateTime.Now,
                TotalPrice = 150,
                Discount = 0,
                ReturnDate = null
                //RentedCars = new List<RentedCar> { new RentedCar { CarId = car1.Id } } 
            };
            var result = rentalManager.Add(agreement);
            Console.WriteLine(result.Message);
        }

        private static void AddDefaultData(CarManager carManager, BrandManager brandManager, ColorManager colorManager, CarTypeManager carTypeManager)
        {
            var brand = new Brand
            {
               Name = "Ford"
            };
            brandManager.Add(brand);

            var color = new Color
            {
                Name = "Siyah"
            };
            colorManager.Add(color);

            var carType = new CarType
            {
                Name = "Hatchback"
            };
            carTypeManager.Add(carType);

            var car = new Car
            {
                Model = "Fiesta",
                ModelYear = "2012",
                ColorId = 1,
                BrandId = 1,
                CarTypeId = 1,
                Capacity = 4,
                DailyPrice = 100,

            };
            carManager.Add(car);
        }

        private static void GetIndividualCustomerDetail(IndividualCustomerManager individualCustomerManager)
        {
            var result = individualCustomerManager.GetById(1).Data;
            Console.WriteLine(result.IdentityNo + " " + result.FirstName + " " + result.LastName + " " + result.Email + " " + result.PhoneNumber);
        }

        private static void DeleteUser(UserManager userManager)
        {
            var user = userManager.GetById(1).Data;
            var result = userManager.Delete(user);
            Console.WriteLine(result.Message);
        }

        private static void AddIndividualCustomer(IndividualCustomerManager individualCustomerManager)
        {
            var customer = new IndividualCustomer
            {
                IdentityNo = "12345678910",
                FirstName = "Ali",
                LastName = "Yaman",
                DOB = Convert.ToDateTime("10/10/1990"),
                PhoneNumber = "05556667788",
                Address = "İzmir",
                Email = "ali.yaman@hotmail.com",
                //PasswordHash = "12345",
                JoinDate = DateTime.Now
            };

            individualCustomerManager.Add(customer);
        }

        private static void AddCorporateCustomer(CorporateCustomerManager corporateCustomerManager)
        {
            var corporate = new CorporateCustomer
            {
                CompanyName = "ABC LTD.",
                TaxNumber = "1234567891",
                Address = "İstanbul Şişli",
                Email = "organizator@abcLtd.com",
                //PasswordHash = "12345",
                PhoneNumber = "02124445566",
                JoinDate = DateTime.Now
            };
            var result = corporateCustomerManager.Add(corporate);
            Console.WriteLine(result.Message);
        }
        #endregion




    }
}
