using CarRental.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.DataAccess.Concrete.Configurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();
            builder.Property(b => b.Name).IsRequired(true);
            builder.Property(b => b.Name).HasMaxLength(30);

            builder.ToTable("Brands");

            builder.HasData(
                new Brand
                {
                    Id = 1,
                    Name = "Skoda"
                },
                new Brand
                {
                    Id = 2,
                    Name = "Volvo"
                },
                new Brand
                {
                    Id = 3,
                    Name = "Volkswagen"
                },
                new Brand
                {
                    Id = 4,
                    Name = "Ford"
                },
                new Brand
                {
                    Id = 5,
                    Name = "Peugeot"
                },
                new Brand
                {
                    Id = 6,
                    Name = "BMW"
                });
        }
    }
}
