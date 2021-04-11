using CarRental.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.DataAccess.Concrete.Configurations
{
    public class CarTypeConfiguration : IEntityTypeConfiguration<CarType>
    {
        public void Configure(EntityTypeBuilder<CarType> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(15);

            builder.ToTable("CarTypes");

            builder.HasData(
                new CarType
                {
                    Id = 1,
                    Name = "Sedan"
                },
                new CarType
                {
                    Id = 2,
                    Name = "Hatchback"
                },
                new CarType
                {
                    Id = 3,
                    Name = "SUV"
                },
                new CarType
                {
                    Id = 4,
                    Name = "Minivan"
                },
                new CarType
                {
                    Id = 5,
                    Name = "Micro"
                });
        }
    }
}
