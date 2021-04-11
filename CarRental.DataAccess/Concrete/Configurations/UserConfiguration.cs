using CarRental.Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.DataAccess.Concrete.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).UseIdentityColumn().ValueGeneratedOnAdd();
            builder.Property(u => u.UserName).IsRequired().HasMaxLength(30);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(50);
            builder.Property(u => u.PasswordHash).IsRequired();
            builder.Property(u => u.PasswordSalt).IsRequired();
            builder.Property(u => u.JoinDate).IsRequired().HasColumnType("date");

            builder.ToTable("Users");

            //builder.HasData(
            //    new User
            //    {
            //        Id = 1,
            //        Email = "admin@carRental.com",
            //        PasswordHash = "12345",
            //        JoinDate = DateTime.Now
            //    }
            //   );

        
        }

    }
}
