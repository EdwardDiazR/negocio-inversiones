USE [master]
GO
/****** Object:  Database [NegocioInversiones]    Script Date: 3/24/2024 8:00:31 PM ******/
CREATE DATABASE [NegocioInversiones]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NegocioInversiones', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\NegocioInversiones.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'NegocioInversiones_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\NegocioInversiones_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [NegocioInversiones] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NegocioInversiones].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NegocioInversiones] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NegocioInversiones] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NegocioInversiones] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NegocioInversiones] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NegocioInversiones] SET ARITHABORT OFF 
GO
ALTER DATABASE [NegocioInversiones] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NegocioInversiones] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NegocioInversiones] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NegocioInversiones] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NegocioInversiones] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NegocioInversiones] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NegocioInversiones] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NegocioInversiones] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NegocioInversiones] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NegocioInversiones] SET  ENABLE_BROKER 
GO
ALTER DATABASE [NegocioInversiones] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NegocioInversiones] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NegocioInversiones] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NegocioInversiones] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NegocioInversiones] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NegocioInversiones] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [NegocioInversiones] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NegocioInversiones] SET RECOVERY FULL 
GO
ALTER DATABASE [NegocioInversiones] SET  MULTI_USER 
GO
ALTER DATABASE [NegocioInversiones] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NegocioInversiones] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NegocioInversiones] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NegocioInversiones] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [NegocioInversiones] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [NegocioInversiones] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'NegocioInversiones', N'ON'
GO
ALTER DATABASE [NegocioInversiones] SET QUERY_STORE = ON
GO
ALTER DATABASE [NegocioInversiones] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [NegocioInversiones]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 3/24/2024 8:00:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[customer_product]    Script Date: 3/24/2024 8:00:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customer_product](
	[product_id] [int] IDENTITY(1,1) NOT NULL,
	[product_type_id] [int] NOT NULL,
	[product_customer_id] [int] NOT NULL,
 CONSTRAINT [PK_customer_product] PRIMARY KEY CLUSTERED 
(
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[loan]    Script Date: 3/24/2024 8:00:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[loan](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[LoanStatusId] [int] NOT NULL,
	[LoanTypeId] [int] NOT NULL,
	[BeneficiaryCustomerId] [int] NOT NULL,
	[CoSignerId] [int] NULL,
	[Amount] [float] NOT NULL,
	[CapitalBalance] [float] NOT NULL,
	[InterestBalance] [float] NOT NULL,
	[CancellationAmount] [float] NOT NULL,
	[MontoCuota] [float] NOT NULL,
	[MontoMora] [float] NOT NULL,
	[Interest] [float] NOT NULL,
	[EndDate] [datetime2](7) NULL,
	[PlazoEnMeses] [int] NOT NULL,
	[GuaranteeTypeId] [int] NOT NULL,
	[IsCancelled] [bit] NOT NULL,
	[IsBlocked] [bit] NOT NULL,
	[IsInLegal] [bit] NOT NULL,
	[IsWithdrawn] [bit] NOT NULL,
	[MesesTasaFija] [int] NOT NULL,
	[NextPaymentDate] [datetime2](7) NULL,
	[StartDate] [datetime2](7) NULL,
 CONSTRAINT [PK_loan] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoanRequest]    Script Date: 3/24/2024 8:00:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoanRequest](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[RequestDate] [datetime2](7) NOT NULL,
	[RequestedLoanAmount] [float] NOT NULL,
	[RequestedLoanTime] [int] NOT NULL,
	[LoanType] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[LoanAmount] [float] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[RequestStatus] [int] NOT NULL,
	[IsClosed] [bit] NOT NULL,
	[ApprovedAmount] [float] NOT NULL,
	[ApprovedInterestRate] [float] NOT NULL,
	[ApprovedTimeInMonths] [int] NOT NULL,
	[RequestClosingDate] [datetime2](7) NOT NULL,
	[EmployeeCode] [int] NOT NULL,
	[GeneralRequestId] [bigint] NOT NULL,
 CONSTRAINT [PK_LoanRequest] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[personal_customer]    Script Date: 3/24/2024 8:00:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[personal_customer](
	[customer_id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[MiddleName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[SecondLastName] [nvarchar](max) NULL,
	[customer_civil_id] [nvarchar](max) NOT NULL,
	[customer_civil_id_type] [int] NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[PhoneNumber] [nvarchar](max) NOT NULL,
	[ResidentialPhoneNumber] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[City] [nvarchar](max) NOT NULL,
	[Country] [nvarchar](max) NOT NULL,
	[CustomerDob] [datetime2](7) NOT NULL,
	[MonthlyIncome] [float] NOT NULL,
	[WorkPlace] [nvarchar](max) NULL,
	[CustomerAge] [int] NOT NULL,
	[CustomerProfileStatus] [int] NOT NULL,
	[WorkPlaceVerified] [bit] NOT NULL,
	[IncomeVerified] [bit] NOT NULL,
	[Gender] [nvarchar](max) NOT NULL,
	[LastTimeProfileUpdated] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_personal_customer] PRIMARY KEY CLUSTERED 
(
	[customer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[request]    Script Date: 3/24/2024 8:00:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[request](
	[request_id] [bigint] IDENTITY(1,1) NOT NULL,
	[request_type] [int] NOT NULL,
	[request_date] [datetime2](7) NOT NULL,
	[request_customer_id] [int] NOT NULL,
 CONSTRAINT [PK_request] PRIMARY KEY CLUSTERED 
(
	[request_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[loan] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsWithdrawn]
GO
ALTER TABLE [dbo].[loan] ADD  DEFAULT ((0)) FOR [MesesTasaFija]
GO
ALTER TABLE [dbo].[LoanRequest] ADD  DEFAULT (CONVERT([bigint],(0))) FOR [GeneralRequestId]
GO
ALTER TABLE [dbo].[personal_customer] ADD  DEFAULT (N'') FOR [Gender]
GO
ALTER TABLE [dbo].[personal_customer] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [LastTimeProfileUpdated]
GO
USE [master]
GO
ALTER DATABASE [NegocioInversiones] SET  READ_WRITE 
GO
