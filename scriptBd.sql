USE [master]
GO
/****** Object:  Database [BdFlores]    Script Date: 31/7/2023 23:29:50 ******/
CREATE DATABASE [BdFlores]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BdFlores', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\BdFlores.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BdFlores_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\BdFlores_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [BdFlores] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BdFlores].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BdFlores] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BdFlores] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BdFlores] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BdFlores] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BdFlores] SET ARITHABORT OFF 
GO
ALTER DATABASE [BdFlores] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BdFlores] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BdFlores] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BdFlores] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BdFlores] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BdFlores] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BdFlores] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BdFlores] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BdFlores] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BdFlores] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BdFlores] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BdFlores] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BdFlores] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BdFlores] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BdFlores] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BdFlores] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BdFlores] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BdFlores] SET RECOVERY FULL 
GO
ALTER DATABASE [BdFlores] SET  MULTI_USER 
GO
ALTER DATABASE [BdFlores] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BdFlores] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BdFlores] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BdFlores] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BdFlores] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BdFlores] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BdFlores', N'ON'
GO
ALTER DATABASE [BdFlores] SET QUERY_STORE = ON
GO
ALTER DATABASE [BdFlores] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [BdFlores]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 31/7/2023 23:29:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Color]    Script Date: 31/7/2023 23:29:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Color](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nchar](50) NOT NULL,
 CONSTRAINT [PK_Color] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Especie]    Script Date: 31/7/2023 23:29:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Especie](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nchar](50) NOT NULL,
 CONSTRAINT [PK_Especie] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Flores]    Script Date: 31/7/2023 23:29:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Flores](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](400) NULL,
	[precio] [decimal](18, 0) NULL,
	[Id_especie] [int] NOT NULL,
	[Id_color] [int] NOT NULL,
 CONSTRAINT [PK_Flores] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ramos]    Script Date: 31/7/2023 23:29:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ramos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Cantidad_flores] [int] NOT NULL,
	[Id_flores] [int] NOT NULL,
	[Id_categoria] [int] NULL,
	[precio_total] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Ramos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Flores]  WITH NOCHECK ADD  CONSTRAINT [FK_Flores_Color] FOREIGN KEY([Id_color])
REFERENCES [dbo].[Color] ([Id])
GO
ALTER TABLE [dbo].[Flores] NOCHECK CONSTRAINT [FK_Flores_Color]
GO
ALTER TABLE [dbo].[Flores]  WITH NOCHECK ADD  CONSTRAINT [FK_Flores_Especie] FOREIGN KEY([Id_especie])
REFERENCES [dbo].[Especie] ([Id])
GO
ALTER TABLE [dbo].[Flores] NOCHECK CONSTRAINT [FK_Flores_Especie]
GO
ALTER TABLE [dbo].[Ramos]  WITH CHECK ADD  CONSTRAINT [FK_Ramos_Categoria] FOREIGN KEY([Id_categoria])
REFERENCES [dbo].[Categoria] ([Id])
GO
ALTER TABLE [dbo].[Ramos] CHECK CONSTRAINT [FK_Ramos_Categoria]
GO
ALTER TABLE [dbo].[Ramos]  WITH CHECK ADD  CONSTRAINT [FK_Ramos_Flores] FOREIGN KEY([Id_flores])
REFERENCES [dbo].[Flores] ([Id])
GO
ALTER TABLE [dbo].[Ramos] CHECK CONSTRAINT [FK_Ramos_Flores]
GO
/****** Object:  StoredProcedure [dbo].[SP_MostrarColores]    Script Date: 31/7/2023 23:29:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_MostrarColores]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id, nombre from Color order by nombre asc
END
GO
/****** Object:  StoredProcedure [dbo].[SP_MostrarEspecies]    Script Date: 31/7/2023 23:29:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_MostrarEspecies]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id, nombre from Especie order by nombre asc
END
GO
USE [master]
GO
ALTER DATABASE [BdFlores] SET  READ_WRITE 
GO
