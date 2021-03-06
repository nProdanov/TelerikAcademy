USE [master]
GO
/****** Object:  Database [PersonalAdresses]    Script Date: 10/19/2016 9:34:27 AM ******/
CREATE DATABASE [PersonalAdresses]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PersonalAdresses', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\PersonalAdresses.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PersonalAdresses_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\PersonalAdresses_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [PersonalAdresses] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PersonalAdresses].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PersonalAdresses] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PersonalAdresses] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PersonalAdresses] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PersonalAdresses] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PersonalAdresses] SET ARITHABORT OFF 
GO
ALTER DATABASE [PersonalAdresses] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PersonalAdresses] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PersonalAdresses] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PersonalAdresses] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PersonalAdresses] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PersonalAdresses] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PersonalAdresses] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PersonalAdresses] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PersonalAdresses] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PersonalAdresses] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PersonalAdresses] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PersonalAdresses] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PersonalAdresses] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PersonalAdresses] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PersonalAdresses] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PersonalAdresses] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PersonalAdresses] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PersonalAdresses] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PersonalAdresses] SET  MULTI_USER 
GO
ALTER DATABASE [PersonalAdresses] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PersonalAdresses] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PersonalAdresses] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PersonalAdresses] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PersonalAdresses] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PersonalAdresses] SET QUERY_STORE = OFF
GO
USE [PersonalAdresses]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [PersonalAdresses]
GO
/****** Object:  Table [dbo].[Adresses]    Script Date: 10/19/2016 9:34:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Adresses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AddressText] [nvarchar](100) NOT NULL,
	[TownId] [int] NOT NULL,
 CONSTRAINT [PK_Adresses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Continents]    Script Date: 10/19/2016 9:34:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Continents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Continents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Countries]    Script Date: 10/19/2016 9:34:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ContinentId] [int] NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Persons]    Script Date: 10/19/2016 9:34:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[AddressId] [int] NOT NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Towns]    Script Date: 10/19/2016 9:34:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Towns](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CountryId] [int] NOT NULL,
 CONSTRAINT [PK_Towns] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Adresses] ON 

INSERT [dbo].[Adresses] ([Id], [AddressText], [TownId]) VALUES (1, N'Bul Bulgaria 1', 1)
INSERT [dbo].[Adresses] ([Id], [AddressText], [TownId]) VALUES (2, N'Bul Al Malinov 37', 1)
INSERT [dbo].[Adresses] ([Id], [AddressText], [TownId]) VALUES (3, N'Suha Reka', 1)
INSERT [dbo].[Adresses] ([Id], [AddressText], [TownId]) VALUES (4, N'Mladost 2 255', 1)
INSERT [dbo].[Adresses] ([Id], [AddressText], [TownId]) VALUES (5, N'St grad 54', 1)
SET IDENTITY_INSERT [dbo].[Adresses] OFF
SET IDENTITY_INSERT [dbo].[Continents] ON 

INSERT [dbo].[Continents] ([Id], [name]) VALUES (1, N'Europe')
INSERT [dbo].[Continents] ([Id], [name]) VALUES (2, N'North America')
INSERT [dbo].[Continents] ([Id], [name]) VALUES (3, N'South America')
INSERT [dbo].[Continents] ([Id], [name]) VALUES (4, N'Asia')
INSERT [dbo].[Continents] ([Id], [name]) VALUES (5, N'Africa')
SET IDENTITY_INSERT [dbo].[Continents] OFF
SET IDENTITY_INSERT [dbo].[Countries] ON 

INSERT [dbo].[Countries] ([Id], [Name], [ContinentId]) VALUES (1, N'Bulgaria', 1)
INSERT [dbo].[Countries] ([Id], [Name], [ContinentId]) VALUES (2, N'USA', 2)
INSERT [dbo].[Countries] ([Id], [Name], [ContinentId]) VALUES (3, N'UAR', 5)
SET IDENTITY_INSERT [dbo].[Countries] OFF
SET IDENTITY_INSERT [dbo].[Persons] ON 

INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [AddressId]) VALUES (1, N'Ivan', N'Ivanov', 2)
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [AddressId]) VALUES (2, N'Dancho', N'Dinev', 4)
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [AddressId]) VALUES (3, N'Mihail', N'Nonev', 3)
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [AddressId]) VALUES (4, N'Georgi', N'Nikolov', 1)
SET IDENTITY_INSERT [dbo].[Persons] OFF
SET IDENTITY_INSERT [dbo].[Towns] ON 

INSERT [dbo].[Towns] ([Id], [Name], [CountryId]) VALUES (1, N'Sofia', 1)
INSERT [dbo].[Towns] ([Id], [Name], [CountryId]) VALUES (2, N'Bourgas', 1)
INSERT [dbo].[Towns] ([Id], [Name], [CountryId]) VALUES (3, N'Varna', 1)
INSERT [dbo].[Towns] ([Id], [Name], [CountryId]) VALUES (4, N'Ruse', 1)
INSERT [dbo].[Towns] ([Id], [Name], [CountryId]) VALUES (5, N'Stara Zagora', 1)
SET IDENTITY_INSERT [dbo].[Towns] OFF
USE [master]
GO
ALTER DATABASE [PersonalAdresses] SET  READ_WRITE 
GO
