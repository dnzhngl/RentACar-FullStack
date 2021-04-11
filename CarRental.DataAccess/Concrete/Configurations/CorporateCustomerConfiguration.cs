using CarRental.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.DataAccess.Concrete.Configurations
{
    public class CorporateCustomerConfiguration : IEntityTypeConfiguration<CorporateCustomer>
    {
        public void Configure(EntityTypeBuilder<CorporateCustomer> builder)
        {
            builder.Property(c => c.CompanyName).IsRequired().HasMaxLength(50);
            builder.Property(c => c.TaxNumber).IsRequired().HasMaxLength(10).IsFixedLength();

            builder.ToTable("CorporateCustomers");
        }
    }
}
