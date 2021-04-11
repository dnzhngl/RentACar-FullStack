using CarRental.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.DataAccess.Concrete.Configurations
{
    public class CarImageConfiguration : IEntityTypeConfiguration<CarImage>
    {
        public void Configure(EntityTypeBuilder<CarImage> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).ValueGeneratedOnAdd();
            builder.Property(i => i.CarId).IsRequired(true);
            builder.Property(i => i.Date).IsRequired(true);
            builder.Property(i => i.ImagePath).IsRequired(true);

            builder.HasOne(i => i.Car).WithMany(c => c.Images).HasForeignKey(i => i.CarId);

            builder.ToTable("CarImages");
        }
    }
}
