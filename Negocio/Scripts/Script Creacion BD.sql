
CREATE DATABASE [PersonasDB]
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PersonasDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PersonasDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PersonasDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PersonasDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PersonasDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PersonasDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [PersonasDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PersonasDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PersonasDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PersonasDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PersonasDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PersonasDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PersonasDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PersonasDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PersonasDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PersonasDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PersonasDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PersonasDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PersonasDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PersonasDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PersonasDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PersonasDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PersonasDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PersonasDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PersonasDB] SET  MULTI_USER 
GO
ALTER DATABASE [PersonasDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PersonasDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PersonasDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PersonasDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [PersonasDB]
GO
/****** Object:  User [juanisank]    Script Date: 18/6/2019 23:23:47 ******/
CREATE USER [juanisank] FOR LOGIN [juanisank] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Ocupaciones]    Script Date: 18/6/2019 23:23:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ocupaciones](
	[IdOcupacion] [int] NOT NULL,
	[Descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_Ocupacion] PRIMARY KEY CLUSTERED 
(
	[IdOcupacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Personas]    Script Date: 18/6/2019 23:23:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personas](
	[IdPersona] [int] NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Apellido] [varchar](50) NULL,
	[IdOcupacion] [int] NULL,
 CONSTRAINT [PK_Personas] PRIMARY KEY CLUSTERED 
(
	[IdPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Ocupaciones] ([IdOcupacion], [Descripcion]) VALUES (1, N'Medico')
INSERT [dbo].[Ocupaciones] ([IdOcupacion], [Descripcion]) VALUES (2, N'Administrativo')
INSERT [dbo].[Ocupaciones] ([IdOcupacion], [Descripcion]) VALUES (3, N'Contador')
INSERT [dbo].[Ocupaciones] ([IdOcupacion], [Descripcion]) VALUES (4, N'Ingeniero')
INSERT [dbo].[Personas] ([IdPersona], [Nombre], [Apellido], [IdOcupacion]) VALUES (1, N'Juan', N'Perez', 1)
INSERT [dbo].[Personas] ([IdPersona], [Nombre], [Apellido], [IdOcupacion]) VALUES (2, N'Raul', N'Sosa', 2)
INSERT [dbo].[Personas] ([IdPersona], [Nombre], [Apellido], [IdOcupacion]) VALUES (3, N'Maria', N'Garcia', 1)
INSERT [dbo].[Personas] ([IdPersona], [Nombre], [Apellido], [IdOcupacion]) VALUES (4, N'Raul', N'Lopez', 3)
ALTER TABLE [dbo].[Personas]  WITH CHECK ADD  CONSTRAINT [FK_Personas_Personas] FOREIGN KEY([IdOcupacion])
REFERENCES [dbo].[Ocupaciones] ([IdOcupacion])
GO
ALTER TABLE [dbo].[Personas] CHECK CONSTRAINT [FK_Personas_Personas]
GO
/****** Object:  StoredProcedure [dbo].[SP_ListarPersonas]    Script Date: 18/6/2019 23:23:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_ListarPersonas]
AS
BEGIN

select * from Personas

END


GO
/****** Object:  StoredProcedure [dbo].[SP_ObtenerPersona]    Script Date: 18/6/2019 23:23:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_ObtenerPersona]
@IdPersona int
AS
BEGIN

SELECT * from Personas where IdPersona = @IdPersona

END

GO
USE [master]
GO
ALTER DATABASE [PersonasDB] SET  READ_WRITE 
GO
