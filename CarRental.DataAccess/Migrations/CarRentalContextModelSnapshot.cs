﻿// <auto-generated />
using System;
using CarRental.DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarRental.DataAccess.Migrations
{
    [DbContext(typeof(CarRentalContext))]
    partial class CarRentalContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarRental.Entities.Concrete.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Skoda"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Volvo"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Volkswagen"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Ford"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Peugeot"
                        },
                        new
                        {
                            Id = 6,
                            Name = "BMW"
                        });
                });

            modelBuilder.Entity("CarRental.Entities.Concrete.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<byte>("Capacity")
                        .HasColumnType("tinyint");

                    b.Property<int>("CarTypeId")
                        .HasColumnType("int");

                    b.Property<int>("ColorId")
                        .HasColumnType("int");

                    b.Property<double>("DailyPrice")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("ModelYear")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nchar(4)")
                        .IsFixedLength(true);

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CarTypeId");

                    b.HasIndex("ColorId");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandId = 1,
                            Capacity = (byte)4,
                            CarTypeId = 1,
                            ColorId = 3,
                            DailyPrice = 150.0,
                            IsAvailable = true,
                            Model = "SuperB",
                            ModelYear = "2018"
                        },
                        new
                        {
                            Id = 2,
                            BrandId = 1,
                            Capacity = (byte)4,
                            CarTypeId = 1,
                            ColorId = 2,
                            DailyPrice = 100.0,
                            IsAvailable = true,
                            Model = "Octavia",
                            ModelYear = "2015"
                        },
                        new
                        {
                            Id = 3,
                            BrandId = 3,
                            Capacity = (byte)4,
                            CarTypeId = 1,
                            ColorId = 5,
                            DailyPrice = 120.0,
                            IsAvailable = true,
                            Model = "Passat",
                            ModelYear = "2016"
                        },
                        new
                        {
                            Id = 4,
                            BrandId = 4,
                            Capacity = (byte)4,
                            CarTypeId = 2,
                            ColorId = 1,
                            DailyPrice = 120.0,
                            IsAvailable = true,
                            Model = "Focus",
                            ModelYear = "2016"
                        },
                        new
                        {
                            Id = 5,
                            BrandId = 5,
                            Capacity = (byte)4,
                            CarTypeId = 3,
                            ColorId = 2,
                            DailyPrice = 180.0,
                            IsAvailable = true,
                            Model = "SUV 3008",
                            ModelYear = "2019"
                        });
                });

            modelBuilder.Entity("CarRental.Entities.Concrete.CarType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("CarTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Sedan"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Hatchback"
                        },
                        new
                        {
                            Id = 3,
                            Name = "SUV"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Minivan"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Micro"
                        });
                });

            modelBuilder.Entity("CarRental.Entities.Concrete.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Colors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Siyah"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Beyaz"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Gri"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Kırmızı"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Lacivert"
                        });
                });

            modelBuilder.Entity("CarRental.Entities.Concrete.Rental", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<float?>("Discount")
                        .HasColumnType("real");

                    b.Property<DateTime>("RentDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<double?>("TotalPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Rentals");
                });

            modelBuilder.Entity("CarRental.Entities.Concrete.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("JoinDate")
                        .HasColumnType("date");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "admin@carRental.com",
                            JoinDate = new DateTime(2021, 2, 20, 22, 18, 7, 258, DateTimeKind.Local).AddTicks(3786),
                            PasswordHash = "12345"
                        });
                });

            modelBuilder.Entity("CarRental.Entities.Concrete.Customer", b =>
                {
                    b.HasBaseType("CarRental.Entities.Concrete.User");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("CarRental.Entities.Concrete.CorporateCustomer", b =>
                {
                    b.HasBaseType("CarRental.Entities.Concrete.Customer");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TaxNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength(true);

                    b.ToTable("CorporateCustomers");
                });

            modelBuilder.Entity("CarRental.Entities.Concrete.IndividualCustomer", b =>
                {
                    b.HasBaseType("CarRental.Entities.Concrete.Customer");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("IdentityNo")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nchar(11)")
                        .IsFixedLength(true);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.ToTable("IndividualCustomers");
                });

            modelBuilder.Entity("CarRental.Entities.Concrete.Car", b =>
                {
                    b.HasOne("CarRental.Entities.Concrete.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarRental.Entities.Concrete.CarType", "CarType")
                        .WithMany()
                        .HasForeignKey("CarTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarRental.Entities.Concrete.Color", "Color")
                        .WithMany()
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("CarType");

                    b.Navigation("Color");
                });

            modelBuilder.Entity("CarRental.Entities.Concrete.Rental", b =>
                {
                    b.HasOne("CarRental.Entities.Concrete.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarRental.Entities.Concrete.Customer", "Customer")
                        .WithMany("Rentals")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("CarRental.Entities.Concrete.Customer", b =>
                {
                    b.HasOne("CarRental.Entities.Concrete.User", null)
                        .WithOne()
                        .HasForeignKey("CarRental.Entities.Concrete.Customer", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarRental.Entities.Concrete.CorporateCustomer", b =>
                {
                    b.HasOne("CarRental.Entities.Concrete.Customer", null)
                        .WithOne()
                        .HasForeignKey("CarRental.Entities.Concrete.CorporateCustomer", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarRental.Entities.Concrete.IndividualCustomer", b =>
                {
                    b.HasOne("CarRental.Entities.Concrete.Customer", null)
                        .WithOne()
                        .HasForeignKey("CarRental.Entities.Concrete.IndividualCustomer", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarRental.Entities.Concrete.Customer", b =>
                {
                    b.Navigation("Rentals");
                });
#pragma warning restore 612, 618
        }
    }
}
