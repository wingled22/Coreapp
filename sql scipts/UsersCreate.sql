USE [capstone]
GO

/****** Object:  Table [dbo].[Category]    Script Date: 12/11/2020 12:01:49 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Firstname] [varchar](100) NULL,
	[Lastname] [varchar](100) NULL,
	[Gender] [varchar](15) NULL,
	[Email] [varchar](100) NOT NULL,
	[Password] [varchar](100) NOT NULL
	)
GO


