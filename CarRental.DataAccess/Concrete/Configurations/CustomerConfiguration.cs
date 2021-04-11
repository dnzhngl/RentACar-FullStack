using CarRental.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.DataAccess.Concrete.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(c => c.PhoneNumber).IsRequired().HasMaxLength(15);
            builder.Property(c => c.Address).IsRequired().HasMaxLength(100);
            builder.Property(c => c.JoinDate).IsRequired().HasColumnType("date");

            builder.ToTable("Customers");
            //builder.HasData(
            //    new Customer
            //    {
            //        Id = 1,
            //        Email = "admin@carRental.com",
            //        PasswordHash = "12345",
            //        JoinDate = DateTime.Now,
            //        PhoneNumber = "05556667788",
            //        Address = "Dünya"
            //    });
        }
    }
}
