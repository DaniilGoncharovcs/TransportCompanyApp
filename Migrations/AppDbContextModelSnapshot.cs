﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace TransportCompanyApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AutoEmployee", b =>
                {
                    b.Property<int>("AutosAutoId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeesEmployeeId")
                        .HasColumnType("int");

                    b.HasKey("AutosAutoId", "EmployeesEmployeeId");

                    b.HasIndex("EmployeesEmployeeId");

                    b.ToTable("AutoEmployee");
                });

            modelBuilder.Entity("TransportCompany.Models.Auto", b =>
                {
                    b.Property<int>("AutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AutoId"), 1L, 1);

                    b.Property<int>("AutoTypeId")
                        .HasColumnType("int");

                    b.Property<int>("BodyNumber")
                        .HasColumnType("int");

                    b.Property<int>("CarModelId")
                        .HasColumnType("int");

                    b.Property<int>("EngineNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("MaintenanceDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RegisterNumber")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("AutoId");

                    b.HasIndex("AutoTypeId");

                    b.HasIndex("CarModelId");

                    b.ToTable("Autos");
                });

            modelBuilder.Entity("TransportCompany.Models.AutoType", b =>
                {
                    b.Property<int>("AutoTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AutoTypeId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("AutoTypeId");

                    b.ToTable("AutoTypes");
                });

            modelBuilder.Entity("TransportCompany.Models.Cargo", b =>
                {
                    b.Property<int>("CargoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CargoId"), 1L, 1);

                    b.Property<int>("CargoTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Features")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CargoId");

                    b.HasIndex("CargoTypeId");

                    b.ToTable("Cargos");
                });

            modelBuilder.Entity("TransportCompany.Models.CargoType", b =>
                {
                    b.Property<int>("CargoTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CargoTypeId"), 1L, 1);

                    b.Property<int>("AutoTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CargoTypeId");

                    b.HasIndex("AutoTypeId");

                    b.ToTable("CargoTypes");
                });

            modelBuilder.Entity("TransportCompany.Models.CarModel", b =>
                {
                    b.Property<int>("CarModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarModelId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Specifications")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CarModelId");

                    b.ToTable("CarModels");
                });

            modelBuilder.Entity("TransportCompany.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("FIO")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.Property<string>("Passport")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("EmployeeId");

                    b.HasIndex("JobId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("TransportCompany.Models.Job", b =>
                {
                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Requirements")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Responsibilities")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("JobId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("TransportCompany.Models.Voyage", b =>
                {
                    b.Property<int>("VoyageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VoyageId"), 1L, 1);

                    b.Property<int>("AutoId")
                        .HasColumnType("int");

                    b.Property<int>("CargoId")
                        .HasColumnType("int");

                    b.Property<int>("CodeEmployee")
                        .HasColumnType("int");

                    b.Property<string>("Customer")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("datetime2");

                    b.Property<string>("End")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<bool>("IsReturned")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Start")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("VoyageId");

                    b.HasIndex("AutoId");

                    b.HasIndex("CargoId");

                    b.ToTable("Voyages");
                });

            modelBuilder.Entity("AutoEmployee", b =>
                {
                    b.HasOne("TransportCompany.Models.Auto", null)
                        .WithMany()
                        .HasForeignKey("AutosAutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TransportCompany.Models.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeesEmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TransportCompany.Models.Auto", b =>
                {
                    b.HasOne("TransportCompany.Models.AutoType", "AutoType")
                        .WithMany()
                        .HasForeignKey("AutoTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TransportCompany.Models.CarModel", "CarModel")
                        .WithMany("Autos")
                        .HasForeignKey("CarModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AutoType");

                    b.Navigation("CarModel");
                });

            modelBuilder.Entity("TransportCompany.Models.Cargo", b =>
                {
                    b.HasOne("TransportCompany.Models.CargoType", "CargoType")
                        .WithMany("Cargos")
                        .HasForeignKey("CargoTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CargoType");
                });

            modelBuilder.Entity("TransportCompany.Models.CargoType", b =>
                {
                    b.HasOne("TransportCompany.Models.AutoType", "AutoType")
                        .WithMany("CargoTypes")
                        .HasForeignKey("AutoTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AutoType");
                });

            modelBuilder.Entity("TransportCompany.Models.Employee", b =>
                {
                    b.HasOne("TransportCompany.Models.Job", "Job")
                        .WithMany("Employees")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");
                });

            modelBuilder.Entity("TransportCompany.Models.Voyage", b =>
                {
                    b.HasOne("TransportCompany.Models.Auto", "Auto")
                        .WithMany("Voyages")
                        .HasForeignKey("AutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TransportCompany.Models.Cargo", "Cargo")
                        .WithMany("Voyages")
                        .HasForeignKey("CargoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Auto");

                    b.Navigation("Cargo");
                });

            modelBuilder.Entity("TransportCompany.Models.Auto", b =>
                {
                    b.Navigation("Voyages");
                });

            modelBuilder.Entity("TransportCompany.Models.AutoType", b =>
                {
                    b.Navigation("CargoTypes");
                });

            modelBuilder.Entity("TransportCompany.Models.Cargo", b =>
                {
                    b.Navigation("Voyages");
                });

            modelBuilder.Entity("TransportCompany.Models.CargoType", b =>
                {
                    b.Navigation("Cargos");
                });

            modelBuilder.Entity("TransportCompany.Models.CarModel", b =>
                {
                    b.Navigation("Autos");
                });

            modelBuilder.Entity("TransportCompany.Models.Job", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}