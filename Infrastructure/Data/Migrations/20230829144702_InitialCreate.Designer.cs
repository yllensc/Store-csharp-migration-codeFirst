﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(StoreContext))]
    [Migration("20230829144702_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Core.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NameCountry")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("NameCountry")
                        .IsUnique();

                    b.ToTable("Country", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("IdPerson")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<int>("IdPersonTypeFk")
                        .HasColumnType("int");

                    b.Property<int>("IdProdPerson")
                        .HasColumnType("int");

                    b.Property<int>("IdRegionFk")
                        .HasColumnType("int");

                    b.Property<string>("NamePerson")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("IdPerson")
                        .IsUnique();

                    b.HasIndex("IdPersonTypeFk");

                    b.HasIndex("IdRegionFk");

                    b.ToTable("Person", (string)null);
                });

            modelBuilder.Entity("Core.Entities.PersonType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Description")
                        .IsUnique();

                    b.ToTable("PersonType", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("InternalCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("NameProduct")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Stock")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.Property<int>("StockMax")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.Property<int>("StockMin")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.Property<double>("TotalPrice")
                        .HasMaxLength(15)
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("InternalCode")
                        .IsUnique();

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("Core.Entities.ProductPerson", b =>
                {
                    b.Property<int>("IdProductFK")
                        .HasColumnType("int");

                    b.Property<int>("IdPersonFK")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("PersonId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("IdProductFK", "IdPersonFK");

                    b.HasIndex("PersonId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductPeople");
                });

            modelBuilder.Entity("Core.Entities.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdStateFK")
                        .HasColumnType("int");

                    b.Property<string>("RegionName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("IdStateFK");

                    b.HasIndex("RegionName")
                        .IsUnique();

                    b.ToTable("Region", (string)null);
                });

            modelBuilder.Entity("Core.Entities.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdCountryFK")
                        .HasColumnType("int");

                    b.Property<string>("NameState")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("IdCountryFK");

                    b.HasIndex("NameState")
                        .IsUnique();

                    b.ToTable("State", (string)null);
                });

            modelBuilder.Entity("PersonProduct", b =>
                {
                    b.Property<int>("PersonsId")
                        .HasColumnType("int");

                    b.Property<int>("ProductsId")
                        .HasColumnType("int");

                    b.HasKey("PersonsId", "ProductsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("PersonProduct");
                });

            modelBuilder.Entity("Core.Entities.Person", b =>
                {
                    b.HasOne("Core.Entities.PersonType", "PersonsType")
                        .WithMany("Persons")
                        .HasForeignKey("IdPersonTypeFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Region", "Region")
                        .WithMany("Persons")
                        .HasForeignKey("IdRegionFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonsType");

                    b.Navigation("Region");
                });

            modelBuilder.Entity("Core.Entities.ProductPerson", b =>
                {
                    b.HasOne("Core.Entities.Person", "Person")
                        .WithMany("ProductPersons")
                        .HasForeignKey("PersonId");

                    b.HasOne("Core.Entities.Product", "Product")
                        .WithMany("ProductPersons")
                        .HasForeignKey("ProductId");

                    b.Navigation("Person");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Core.Entities.Region", b =>
                {
                    b.HasOne("Core.Entities.State", "State")
                        .WithMany("Regions")
                        .HasForeignKey("IdStateFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("State");
                });

            modelBuilder.Entity("Core.Entities.State", b =>
                {
                    b.HasOne("Core.Entities.Country", "Country")
                        .WithMany("States")
                        .HasForeignKey("IdCountryFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("PersonProduct", b =>
                {
                    b.HasOne("Core.Entities.Person", null)
                        .WithMany()
                        .HasForeignKey("PersonsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.Country", b =>
                {
                    b.Navigation("States");
                });

            modelBuilder.Entity("Core.Entities.Person", b =>
                {
                    b.Navigation("ProductPersons");
                });

            modelBuilder.Entity("Core.Entities.PersonType", b =>
                {
                    b.Navigation("Persons");
                });

            modelBuilder.Entity("Core.Entities.Product", b =>
                {
                    b.Navigation("ProductPersons");
                });

            modelBuilder.Entity("Core.Entities.Region", b =>
                {
                    b.Navigation("Persons");
                });

            modelBuilder.Entity("Core.Entities.State", b =>
                {
                    b.Navigation("Regions");
                });
#pragma warning restore 612, 618
        }
    }
}