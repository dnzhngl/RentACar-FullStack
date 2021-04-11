using CarRental.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.DataAccess.Concrete.Configurations
{
    public class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(15);

            builder.ToTable("Colors");

            builder.HasData(
                new Color
                {
                    Id = 1,
                    Name = "Siyah" 
                },
                new Color
                {
                    Id = 2,
                    Name = "Beyaz" 
                },
                new Color
                {
                    Id = 3,
                    Name = "Gri" 
                },
                new Color
                {
                    Id = 4,
                    Name = "Kırmızı" 
                },
                new Color
                {
                    Id = 5,
                    Name = "Lacivert" 
                });
        }
    }
}
