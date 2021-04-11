using CarRental.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.DataAccess.Concrete.Configurations
{
    public class IndividualCustomerConfiguration : IEntityTypeConfiguration<IndividualCustomer>
    {
        public void Configure(EntityTypeBuilder<IndividualCustomer> builder)
        {
            builder.Property(i => i.IdentityNo).IsRequired();
            builder.Property(i => i.IdentityNo).HasMaxLength(11).IsFixedLength();
            builder.Property(i => i.FirstName).IsRequired().HasMaxLength(30);
            builder.Property(i => i.LastName).IsRequired().HasMaxLength(30);
            builder.Property(i => i.DOB).HasColumnType("date").IsRequired();

            builder.ToTable("IndividualCustomers");
            //builder.HasData(
            //    new IndividualCustomer
            //    {
            //        Id = 1,
            //        Email = "admin@carRental.com",
            //        PasswordHash = "12345",
            //        JoinDate = DateTime.Now,
            //        PhoneNumber = "05556667788",
            //        Address = "Dünya",
            //        FirstName = "Admin",
            //        LastName = "User",
            //        DOB = Convert.ToDateTime("01.01.1990"),
            //        IdentityNo = "12345678910"
            //    });
        
        }
    }
}
