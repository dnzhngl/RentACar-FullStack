using CarRental.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.DataAccess.Concrete.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Model).IsRequired();
            builder.Property(c => c.Model).HasMaxLength(20);
            builder.Property(c => c.ModelYear).IsRequired();
            builder.Property(c => c.ModelYear).IsFixedLength(true);
            builder.Property(c => c.ModelYear).HasMaxLength(4);
            builder.Property(c => c.DailyPrice).IsRequired();
            builder.Property(c => c.Description).HasMaxLength(500);
            builder.Property(c => c.IsAvailable).IsRequired();

            builder.Property(c => c.BrandId).IsRequired();
            builder.Property(c => c.CarTypeId).IsRequired();
            builder.Property(c => c.ColorId).IsRequired();

            builder.HasOne(c => c.Brand).WithMany(b => b.Cars).HasForeignKey(c => c.BrandId);
            builder.HasOne(c => c.Color).WithMany(b => b.Cars).HasForeignKey(c => c.ColorId);
            builder.HasOne(c => c.CarType).WithMany(b => b.Cars).HasForeignKey(c => c.CarTypeId);

            builder.ToTable("Cars");

            builder.HasData(
                new Car
                {
                    Id = 1,
                    Model = "SuperB",
                    ModelYear = "2018",
                    ColorId = 3,
                    BrandId = 1,
                    CarTypeId = 1,
                    Capacity = 4,
                    DailyPrice = 150,
                    IsAvailable = true
                },
                new Car
                {
                    Id = 2,
                    Model = "Octavia",
                    ModelYear = "2015",
                    ColorId = 2,
                    BrandId = 1,
                    CarTypeId = 1,
                    Capacity = 4,
                    DailyPrice = 100,
                    IsAvailable = true
                },
                new Car
                {
                    Id = 3,
                    Model = "Passat",
                    ModelYear = "2016",
                    ColorId = 5,
                    BrandId = 3,
                    CarTypeId = 1,
                    Capacity = 4,
                    DailyPrice = 120,
                    IsAvailable = true
                },
                new Car
                {
                    Id = 4,
                    Model = "Focus",
                    ModelYear = "2016",
                    ColorId = 1,
                    BrandId = 4,
                    CarTypeId = 2,
                    Capacity = 4,
                    DailyPrice = 120,
                    IsAvailable = true
                },
                new Car
                {
                    Id = 5,
                    Model = "SUV 3008",
                    ModelYear = "2019",
                    ColorId = 2,
                    BrandId = 5,
                    CarTypeId = 3,
                    Capacity = 4,
                    DailyPrice = 180,
                    IsAvailable = true
                });
        }
    }
}
