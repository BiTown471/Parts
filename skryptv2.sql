USE [master]
GO
/****** Object:  Database [PartsDBv4]    Script Date: 19.01.2021 12:53:19 ******/
CREATE DATABASE [PartsDBv4]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PartsDBv4', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\PartsDBv4.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PartsDBv4_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\PartsDBv4_log.ldf' , SIZE = 1040KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PartsDBv4] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PartsDBv4].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PartsDBv4] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PartsDBv4] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PartsDBv4] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PartsDBv4] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PartsDBv4] SET ARITHABORT OFF 
GO
ALTER DATABASE [PartsDBv4] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [PartsDBv4] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [PartsDBv4] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PartsDBv4] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PartsDBv4] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PartsDBv4] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PartsDBv4] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PartsDBv4] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PartsDBv4] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PartsDBv4] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PartsDBv4] SET  ENABLE_BROKER 
GO
ALTER DATABASE [PartsDBv4] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PartsDBv4] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PartsDBv4] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PartsDBv4] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PartsDBv4] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PartsDBv4] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [PartsDBv4] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PartsDBv4] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PartsDBv4] SET  MULTI_USER 
GO
ALTER DATABASE [PartsDBv4] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PartsDBv4] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PartsDBv4] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PartsDBv4] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [PartsDBv4]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 19.01.2021 12:53:19 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Klienci]    Script Date: 19.01.2021 12:53:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Klienci](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[nazwa] [nvarchar](max) NOT NULL,
	[adres] [nvarchar](max) NOT NULL,
	[email] [nvarchar](max) NOT NULL,
	[haslo] [nvarchar](max) NOT NULL,
	[nr_tel] [int] NOT NULL,
 CONSTRAINT [PK_Klienci] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Pozycja]    Script Date: 19.01.2021 12:53:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pozycja](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[nazwa] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Pozycja] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Pracownicy]    Script Date: 19.01.2021 12:53:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pracownicy](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[imie] [nvarchar](max) NOT NULL,
	[nazwisko] [nvarchar](max) NULL,
	[email] [nvarchar](50) NOT NULL,
	[haslo] [nvarchar](max) NOT NULL,
	[wypłata] [int] NOT NULL,
	[ID_pozycja] [int] NOT NULL,
 CONSTRAINT [PK_Pracownicy] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Produkty]    Script Date: 19.01.2021 12:53:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Produkty](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[nazwa] [nvarchar](max) NULL,
	[cena] [int] NOT NULL,
	[ilość_magazynowa] [int] NOT NULL,
 CONSTRAINT [PK_Produkty] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Zamowienia]    Script Date: 19.01.2021 12:53:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Zamowienia](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_klienta] [int] NOT NULL,
	[ID_Produktu] [int] NOT NULL,
	[ilość] [int] NOT NULL,
	[suma_zamowienia] [int] NOT NULL,
 CONSTRAINT [PK_Zamowienia] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
USE [master]
GO
ALTER DATABASE [PartsDBv4] SET  READ_WRITE 
GO
