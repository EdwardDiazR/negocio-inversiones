﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NegocioInversiones.Data;

#nullable disable

namespace NegocioInversiones.Migrations
{
    [DbContext(typeof(SqlServerContext))]
    partial class SqlServerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NegocioInversiones.Models.CustomerModels.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("customer_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CivilId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("customer_civil_id");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerAge")
                        .HasColumnType("int");

                    b.Property<int>("CustomerCivilIdType")
                        .HasColumnType("int")
                        .HasColumnName("customer_civil_id_type");

                    b.Property<DateTime>("CustomerDob")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerProfileStatus")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IncomeVerified")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastTimeProfileUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("MonthlyIncome")
                        .HasColumnType("float");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResidentialPhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkPlace")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("WorkPlaceVerified")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("personal_customer");
                });

            modelBuilder.Entity("NegocioInversiones.Models.CustomerProduct.CustomerProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("product_customer_id");

                    b.Property<int>("ProductType")
                        .HasColumnType("int")
                        .HasColumnName("product_type_id");

                    b.HasKey("Id");

                    b.ToTable("customer_product");
                });

            modelBuilder.Entity("NegocioInversiones.Models.LoanModel.Loan", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int>("BeneficiaryCustomerId")
                        .HasColumnType("int");

                    b.Property<double>("CancellationAmount")
                        .HasColumnType("float");

                    b.Property<double>("CapitalBalance")
                        .HasColumnType("float");

                    b.Property<int?>("CoSignerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("GuaranteeTypeId")
                        .HasColumnType("int");

                    b.Property<double>("Interest")
                        .HasColumnType("float");

                    b.Property<double>("InterestBalance")
                        .HasColumnType("float");

                    b.Property<bool>("IsBlocked")
                        .HasColumnType("bit");

                    b.Property<bool>("IsCancelled")
                        .HasColumnType("bit");

                    b.Property<bool>("IsInLegal")
                        .HasColumnType("bit");

                    b.Property<bool>("IsWithdrawn")
                        .HasColumnType("bit");

                    b.Property<int>("LoanStatusId")
                        .HasColumnType("int");

                    b.Property<int>("LoanTypeId")
                        .HasColumnType("int");

                    b.Property<int>("MesesTasaFija")
                        .HasColumnType("int");

                    b.Property<double>("MontoCuota")
                        .HasColumnType("float");

                    b.Property<double>("MontoMora")
                        .HasColumnType("float");

                    b.Property<DateTime?>("NextPaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PlazoEnMeses")
                        .HasColumnType("int");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("loan");
                });

            modelBuilder.Entity("NegocioInversiones.Models.Request.Request", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("request_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("request_customer_id");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("request_date");

                    b.Property<int>("Type")
                        .HasColumnType("int")
                        .HasColumnName("request_type");

                    b.HasKey("Id");

                    b.ToTable("request");
                });

            modelBuilder.Entity("NegocioInversiones.Models.SolicitudModels.LoanRequest", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<double>("ApprovedAmount")
                        .HasColumnType("float");

                    b.Property<double>("ApprovedInterestRate")
                        .HasColumnType("float");

                    b.Property<int>("ApprovedTimeInMonths")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeCode")
                        .HasColumnType("int");

                    b.Property<long>("GeneralRequestId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsClosed")
                        .HasColumnType("bit");

                    b.Property<double>("LoanAmount")
                        .HasColumnType("float");

                    b.Property<int>("LoanType")
                        .HasColumnType("int");

                    b.Property<DateTime>("RequestClosingDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RequestStatus")
                        .HasColumnType("int");

                    b.Property<double>("RequestedLoanAmount")
                        .HasColumnType("float");

                    b.Property<int>("RequestedLoanTime")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("LoanRequest");
                });
#pragma warning restore 612, 618
        }
    }
}
