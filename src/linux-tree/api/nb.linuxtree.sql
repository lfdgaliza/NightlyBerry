USE [nb.linuxtree]
GO
/****** Object:  Table [dbo].[Distro]    Script Date: 1/12/2019 3:09:29 PM ******/
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
/****** Object:  Table [dbo].[DistroDerivation]    Script Date: 1/12/2019 3:09:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DistroDerivation](
	[Id] [uniqueidentifier] NOT NULL,
	[DistroId] [uniqueidentifier] NOT NULL,
	[BasedOnId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_DistroDerivation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DistroDerivation]  WITH CHECK ADD  CONSTRAINT [FK_DistroDerivation_Distro] FOREIGN KEY([DistroId])
REFERENCES [dbo].[Distro] ([Id])
GO
ALTER TABLE [dbo].[DistroDerivation] CHECK CONSTRAINT [FK_DistroDerivation_Distro]
GO
ALTER TABLE [dbo].[DistroDerivation]  WITH CHECK ADD  CONSTRAINT [FK_DistroDerivation_Distro1] FOREIGN KEY([BasedOnId])
REFERENCES [dbo].[Distro] ([Id])
GO
ALTER TABLE [dbo].[DistroDerivation] CHECK CONSTRAINT [FK_DistroDerivation_Distro1]
GO
USE [master]
GO
ALTER DATABASE [nb.linuxtree] SET  READ_WRITE 
GO
