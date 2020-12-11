USE [capstone]
GO

/****** Object:  Table [dbo].[Store]    Script Date: 12/11/2020 12:27:22 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Store](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Description] [varchar](200) NOT NULL,
	[Address] [varchar](200) NOT NULL,
	[Photo] [varchar](200) NULL,
	[User] [int] null
	)
GO


