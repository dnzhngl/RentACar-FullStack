using CarRental.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Model).NotEmpty().MinimumLength(3);
            RuleFor(c => c.ModelYear).NotEmpty().Length(4);
            RuleFor(c => c.Capacity).NotEmpty();
            RuleFor(c => c.DailyPrice).NotEmpty().GreaterThan(0);
            RuleFor(c => c.IsAvailable).NotEmpty();
            RuleFor(c => c.Description).MaximumLength(200);
            RuleFor(c => c.BrandId).NotEmpty();
            RuleFor(c => c.ColorId).NotEmpty();
            RuleFor(c => c.CarTypeId).NotEmpty();
        }
    }
}
