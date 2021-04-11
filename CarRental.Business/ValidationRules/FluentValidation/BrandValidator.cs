using CarRental.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CarRental.Business.ValidationRules.FluentValidation
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(b => b.Name).NotEmpty().MinimumLength(3);
        }
        

        public bool IsItStartsWithCapitalLetter(string arg)
        {
            var regex = new Regex("[A-Z]");
            return regex.IsMatch(arg[0].ToString());
        }
    }
}
