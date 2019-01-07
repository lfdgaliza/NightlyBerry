USE [master]
GO
/****** Object:  Database [nb.linuxtree]    Script Date: 07-Jan-19 2:36:47 PM ******/
CREATE DATABASE [nb.linuxtree]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'nb.linuxtree', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\nb.linuxtree.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'nb.linuxtree_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\nb.linuxtree_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [nb.linuxtree] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [nb.linuxtree].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [nb.linuxtree] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [nb.linuxtree] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [nb.linuxtree] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [nb.linuxtree] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [nb.linuxtree] SET ARITHABORT OFF 
GO
ALTER DATABASE [nb.linuxtree] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [nb.linuxtree] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [nb.linuxtree] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [nb.linuxtree] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [nb.linuxtree] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [nb.linuxtree] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [nb.linuxtree] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [nb.linuxtree] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [nb.linuxtree] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [nb.linuxtree] SET  DISABLE_BROKER 
GO
ALTER DATABASE [nb.linuxtree] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [nb.linuxtree] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [nb.linuxtree] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [nb.linuxtree] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [nb.linuxtree] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [nb.linuxtree] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [nb.linuxtree] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [nb.linuxtree] SET RECOVERY FULL 
GO
ALTER DATABASE [nb.linuxtree] SET  MULTI_USER 
GO
ALTER DATABASE [nb.linuxtree] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [nb.linuxtree] SET DB_CHAINING OFF 
GO
ALTER DATABASE [nb.linuxtree] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [nb.linuxtree] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [nb.linuxtree] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'nb.linuxtree', N'ON'
GO
ALTER DATABASE [nb.linuxtree] SET QUERY_STORE = OFF
GO
USE [nb.linuxtree]
GO
/****** Object:  Table [dbo].[Distro]    Script Date: 07-Jan-19 2:36:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Distro](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Distro] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DistroDerivation]    Script Date: 07-Jan-19 2:36:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DistroDerivation](
	[Id] [uniqueidentifier] NOT NULL,
	[DistroReleaseId] [uniqueidentifier] NOT NULL,
	[DerivesFromId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_DistroDerivation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DistroRelease]    Script Date: 07-Jan-19 2:36:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DistroRelease](
	[Id] [uniqueidentifier] NOT NULL,
	[VariantId] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[ReleaseDate] [date] NOT NULL,
 CONSTRAINT [PK_DistroRelease] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DistroVariant]    Script Date: 07-Jan-19 2:36:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DistroVariant](
	[Id] [uniqueidentifier] NOT NULL,
	[DistroId] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[IsMain] [bit] NOT NULL,
	[IsOficial] [bit] NOT NULL,
 CONSTRAINT [PK_DistroVariant] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DistroVariant] ADD  CONSTRAINT [DF_DistroVariant_IsMain]  DEFAULT ((0)) FOR [IsMain]
GO
ALTER TABLE [dbo].[DistroVariant] ADD  CONSTRAINT [DF_DistroVariant_IsOficial]  DEFAULT ((0)) FOR [IsOficial]
GO
ALTER TABLE [dbo].[DistroDerivation]  WITH CHECK ADD  CONSTRAINT [FK_DistroDerivation_DistroRelease] FOREIGN KEY([DistroReleaseId])
REFERENCES [dbo].[DistroRelease] ([Id])
GO
ALTER TABLE [dbo].[DistroDerivation] CHECK CONSTRAINT [FK_DistroDerivation_DistroRelease]
GO
ALTER TABLE [dbo].[DistroDerivation]  WITH CHECK ADD  CONSTRAINT [FK_DistroDerivation_DistroRelease1] FOREIGN KEY([DerivesFromId])
REFERENCES [dbo].[DistroRelease] ([Id])
GO
ALTER TABLE [dbo].[DistroDerivation] CHECK CONSTRAINT [FK_DistroDerivation_DistroRelease1]
GO
ALTER TABLE [dbo].[DistroRelease]  WITH CHECK ADD  CONSTRAINT [FK_DistroRelease_DistroVariant] FOREIGN KEY([VariantId])
REFERENCES [dbo].[DistroVariant] ([Id])
GO
ALTER TABLE [dbo].[DistroRelease] CHECK CONSTRAINT [FK_DistroRelease_DistroVariant]
GO
ALTER TABLE [dbo].[DistroVariant]  WITH CHECK ADD  CONSTRAINT [FK_DistroVariant_Distro] FOREIGN KEY([DistroId])
REFERENCES [dbo].[Distro] ([Id])
GO
ALTER TABLE [dbo].[DistroVariant] CHECK CONSTRAINT [FK_DistroVariant_Distro]
GO
USE [master]
GO
ALTER DATABASE [nb.linuxtree] SET  READ_WRITE 
GO
