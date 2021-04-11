using CarRental.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.DataAccess.Concrete.Configurations
{
    public class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.Customer).WithMany(cust => cust.CreditCards).HasForeignKey(c => c.CustomerId);
            builder.Property(c => c.NameOnCard).HasMaxLength(70).IsRequired();
            builder.Property(c => c.CcNumber).HasMaxLength(20).IsRequired();
            builder.Property(c => c.Cvv).HasMaxLength(4).IsRequired();
            builder.Property(c => c.ExpirationMonth).HasMaxLength(2).IsRequired().IsFixedLength();
            builder.Property(c => c.ExpirationYear).HasMaxLength(4).IsRequired().IsFixedLength();

        }
    }
}
