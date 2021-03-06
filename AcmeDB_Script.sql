USE [master]
GO
/****** Object:  Database [AcmeDB]    Script Date: 27/03/2022 03:58:58 a. m. ******/
CREATE DATABASE [AcmeDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ACMEDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\AcmeDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AcmeDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\AcmeDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [AcmeDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AcmeDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AcmeDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AcmeDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AcmeDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AcmeDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AcmeDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [AcmeDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AcmeDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AcmeDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AcmeDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AcmeDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AcmeDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AcmeDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AcmeDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AcmeDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AcmeDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AcmeDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AcmeDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AcmeDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AcmeDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AcmeDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AcmeDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AcmeDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AcmeDB] SET RECOVERY FULL 
GO
ALTER DATABASE [AcmeDB] SET  MULTI_USER 
GO
ALTER DATABASE [AcmeDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AcmeDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AcmeDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AcmeDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AcmeDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AcmeDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'AcmeDB', N'ON'
GO
ALTER DATABASE [AcmeDB] SET QUERY_STORE = OFF
GO
USE [AcmeDB]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 27/03/2022 03:58:58 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[ProductoID] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Marca] [nvarchar](50) NOT NULL,
	[CodigoDeBarras] [nchar](10) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[ProductoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stock]    Script Date: 27/03/2022 03:58:58 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock](
	[ProductoID] [int] NOT NULL,
	[SucursalID] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Precio] [money] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Stock] PRIMARY KEY CLUSTERED 
(
	[ProductoID] ASC,
	[SucursalID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sucursal]    Script Date: 27/03/2022 03:58:58 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sucursal](
	[SucursalID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Ubicacion] [nvarchar](50) NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Sucursal] PRIMARY KEY CLUSTERED 
(
	[SucursalID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Producto] ON 

INSERT [dbo].[Producto] ([ProductoID], [Descripcion], [Nombre], [Marca], [CodigoDeBarras], [Activo]) VALUES (1, N'Chocolate de Barra', N'Chocolate Abuelita', N'Nestle', N'100011    ', 1)
INSERT [dbo].[Producto] ([ProductoID], [Descripcion], [Nombre], [Marca], [CodigoDeBarras], [Activo]) VALUES (2, N'Bebida', N'Bonafina', N'UNIFOODS', N'100012    ', 1)
INSERT [dbo].[Producto] ([ProductoID], [Descripcion], [Nombre], [Marca], [CodigoDeBarras], [Activo]) VALUES (3, N'Producto Lacteo', N'Queso Manchego Alpura', N'Alpura', N'100013    ', 1)
INSERT [dbo].[Producto] ([ProductoID], [Descripcion], [Nombre], [Marca], [CodigoDeBarras], [Activo]) VALUES (4, N'Fritura', N'Papas Sabritas', N'Sabritas', N'100014    ', 1)
INSERT [dbo].[Producto] ([ProductoID], [Descripcion], [Nombre], [Marca], [CodigoDeBarras], [Activo]) VALUES (5, N'Enlatado', N'Frijoles Bayos Enteros', N'La Sieera', N'100015    ', 1)
SET IDENTITY_INSERT [dbo].[Producto] OFF
GO
INSERT [dbo].[Stock] ([ProductoID], [SucursalID], [Cantidad], [Precio], [Activo]) VALUES (1, 1, 96, 38.7400, 1)
INSERT [dbo].[Stock] ([ProductoID], [SucursalID], [Cantidad], [Precio], [Activo]) VALUES (1, 2, 94, 38.6400, 1)
INSERT [dbo].[Stock] ([ProductoID], [SucursalID], [Cantidad], [Precio], [Activo]) VALUES (1, 3, 84, 38.5400, 1)
INSERT [dbo].[Stock] ([ProductoID], [SucursalID], [Cantidad], [Precio], [Activo]) VALUES (1, 4, 76, 38.9400, 1)
INSERT [dbo].[Stock] ([ProductoID], [SucursalID], [Cantidad], [Precio], [Activo]) VALUES (2, 1, 76, 40.2500, 1)
INSERT [dbo].[Stock] ([ProductoID], [SucursalID], [Cantidad], [Precio], [Activo]) VALUES (2, 4, 76, 40.3000, 1)
INSERT [dbo].[Stock] ([ProductoID], [SucursalID], [Cantidad], [Precio], [Activo]) VALUES (3, 3, 84, 34.2500, 1)
INSERT [dbo].[Stock] ([ProductoID], [SucursalID], [Cantidad], [Precio], [Activo]) VALUES (4, 4, 147, 68.4700, 1)
INSERT [dbo].[Stock] ([ProductoID], [SucursalID], [Cantidad], [Precio], [Activo]) VALUES (5, 4, 57, 16.5700, 1)
GO
SET IDENTITY_INSERT [dbo].[Sucursal] ON 

INSERT [dbo].[Sucursal] ([SucursalID], [Nombre], [Ubicacion], [Activo]) VALUES (1, N'Coyoacan', N'Av Santa Ursula', 1)
INSERT [dbo].[Sucursal] ([SucursalID], [Nombre], [Ubicacion], [Activo]) VALUES (2, N'Polanco', N'Av Masaryk', 1)
INSERT [dbo].[Sucursal] ([SucursalID], [Nombre], [Ubicacion], [Activo]) VALUES (3, N'Claveria', N'Av Tezozomoc', 1)
INSERT [dbo].[Sucursal] ([SucursalID], [Nombre], [Ubicacion], [Activo]) VALUES (4, N'Iztacala', N'Av Gustavo Baz', 1)
SET IDENTITY_INSERT [dbo].[Sucursal] OFF
GO
ALTER TABLE [dbo].[Stock]  WITH CHECK ADD  CONSTRAINT [FK_Stock_ProductID] FOREIGN KEY([ProductoID])
REFERENCES [dbo].[Producto] ([ProductoID])
GO
ALTER TABLE [dbo].[Stock] CHECK CONSTRAINT [FK_Stock_ProductID]
GO
ALTER TABLE [dbo].[Stock]  WITH CHECK ADD  CONSTRAINT [FK_Stock_SucursalID] FOREIGN KEY([SucursalID])
REFERENCES [dbo].[Sucursal] ([SucursalID])
GO
ALTER TABLE [dbo].[Stock] CHECK CONSTRAINT [FK_Stock_SucursalID]
GO
USE [master]
GO
ALTER DATABASE [AcmeDB] SET  READ_WRITE 
GO
