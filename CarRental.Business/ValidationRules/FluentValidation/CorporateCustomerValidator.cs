using CarRental.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.ValidationRules.FluentValidation
{
    public class CorporateCustomerValidator : AbstractValidator<CorporateCustomer>
    {
        public CorporateCustomerValidator()
        {
            RuleFor(c => c.CompanyName).NotEmpty().Length(2,50);
            RuleFor(c => c.TaxNumber).NotEmpty().Length(10);
            RuleFor(c => c.Address).NotEmpty().Length(5, 150);
            RuleFor(c => c.PhoneNumber).NotEmpty().Length(9, 20);
            RuleFor(c => c.Email).NotEmpty().Length(11, 30);
            RuleFor(c => c.PasswordHash).NotEmpty();
            RuleFor(c => c.JoinDate).NotEmpty().LessThanOrEqualTo(DateTime.Now);
        }
    }
}
