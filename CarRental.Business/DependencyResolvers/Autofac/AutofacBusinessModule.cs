using Autofac;
using Autofac.Extras.DynamicProxy;
using CarRental.Business.Abstract;
using CarRental.Business.Concrete;
using CarRental.Core.Utilities.Interceptors;
using CarRental.Core.Utilities.Security.Jwt;
using CarRental.DataAccess.Abstract;
using CarRental.DataAccess.Concrete.EntityFramework.Repositories;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.DependencyResolvers.Autofac
{
    /// <summary>
    /// External IoC container.
    /// Registers interfaces with the corresponding classes.
    /// When an interface called, instance of related class created of.
    /// The lifetime of the instance has been given with the registration.
    /// </summary>
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Authentication
            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            // Brand
            builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();

            // Car
            builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
            builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();

            // CarImage
            builder.RegisterType<CarImageManager>().As<ICarImageService>().SingleInstance();
            builder.RegisterType<EfCarImageDal>().As<ICarImageDal>().SingleInstance();

            // CarType
            builder.RegisterType<CarTypeManager>().As<ICarTypeService>().SingleInstance();
            builder.RegisterType<EfCarTypeDal>().As<ICarTypeDal>().SingleInstance();

            // Color
            builder.RegisterType<ColorManager>().As<IColorService>().SingleInstance();
            builder.RegisterType<EfColorDal>().As<IColorDal>().SingleInstance();

            // CorporateCustomer
            builder.RegisterType<CorporateCustomerManager>().As<ICorporateCustomerService>().SingleInstance();
            builder.RegisterType<EfCorporateCustomerDal>().As<ICorporateCustomerDal>().SingleInstance();

            // Customer
            builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();

            // IndividualCustomer
            builder.RegisterType<IndividualCustomerManager>().As<IIndividualCustomerService>().SingleInstance();
            builder.RegisterType<EfIndividualCustomerDal>().As<IIndividualCustomerDal>().SingleInstance();

            // Rental
            builder.RegisterType<RentalManager>().As<IRentalService>().InstancePerDependency();
            builder.RegisterType<EfRentalDal>().As<IRentalDal>().InstancePerDependency();

            // User
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            //credit card
            builder.RegisterType<CreditCardManager>().As<ICreditCardService>().SingleInstance();
            builder.RegisterType<EfCreditCardDal>().As<ICreditCardDal>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
