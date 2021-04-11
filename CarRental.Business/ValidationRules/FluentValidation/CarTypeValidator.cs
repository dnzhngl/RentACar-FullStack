using CarRental.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.ValidationRules.FluentValidation
{
    public class CarTypeValidator : AbstractValidator<CarType>
    {
        public CarTypeValidator()
        {
            RuleFor(c => c.Name).NotEmpty().MinimumLength(3);
        }
    }
}
