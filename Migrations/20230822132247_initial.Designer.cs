﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using dosLogistic.API.Brokers.Storages;

#nullable disable

namespace dosLogistic.API.Migrations
{
    [DbContext(typeof(StorageBroker))]
    [Migration("20230822132247_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("dosLogistic.API.Models.Foundations.Messages.Message", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("dosLogistic.API.Models.Foundations.Parcels.Parcel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParcelStatus")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("ReceiverId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Subcategory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("UserId");

                    b.ToTable("Parcels");
                });

            modelBuilder.Entity("dosLogistic.API.Models.Foundations.Receivers.Receiver", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassportJshshir")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassportNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Region")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Receivers");
                });

            modelBuilder.Entity("dosLogistic.API.Models.Foundations.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("BirthDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassportJshshir")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassportSeriesAndNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3e9128a8-6c64-4964-ba12-d650b5187b6d"),
                            BirthDate = new DateTimeOffset(new DateTime(2023, 8, 22, 18, 22, 47, 45, DateTimeKind.Unspecified).AddTicks(1633), new TimeSpan(0, 5, 0, 0, 0)),
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 8, 22, 18, 22, 47, 45, DateTimeKind.Unspecified).AddTicks(1548), new TimeSpan(0, 5, 0, 0, 0)),
                            Email = "SuperAdmin@email.com",
                            FirstName = "Super Admin",
                            Gender = 0,
                            LastName = "0",
                            PassportJshshir = "0",
                            PassportSeriesAndNumber = "0",
                            Password = "Admin123!@#",
                            PhoneNumber = "0",
                            Role = 0,
                            UpdatedDate = new DateTimeOffset(new DateTime(2023, 8, 22, 18, 22, 47, 45, DateTimeKind.Unspecified).AddTicks(1548), new TimeSpan(0, 5, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("c030d829-7f17-4f99-a888-ebc4f1acbc02"),
                            BirthDate = new DateTimeOffset(new DateTime(2023, 8, 22, 18, 22, 47, 45, DateTimeKind.Unspecified).AddTicks(1684), new TimeSpan(0, 5, 0, 0, 0)),
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 8, 22, 18, 22, 47, 45, DateTimeKind.Unspecified).AddTicks(1548), new TimeSpan(0, 5, 0, 0, 0)),
                            Email = "ManagerAdmin@email.com",
                            FirstName = "Manager Admin",
                            Gender = 0,
                            LastName = "0",
                            PassportJshshir = "0",
                            PassportSeriesAndNumber = "0",
                            Password = "Admin123!@#",
                            PhoneNumber = "0",
                            Role = 1,
                            UpdatedDate = new DateTimeOffset(new DateTime(2023, 8, 22, 18, 22, 47, 45, DateTimeKind.Unspecified).AddTicks(1548), new TimeSpan(0, 5, 0, 0, 0))
                        });
                });

            modelBuilder.Entity("dosLogistic.API.Models.Foundations.Parcels.Parcel", b =>
                {
                    b.HasOne("dosLogistic.API.Models.Foundations.Receivers.Receiver", "Receiver")
                        .WithMany()
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dosLogistic.API.Models.Foundations.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Receiver");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}