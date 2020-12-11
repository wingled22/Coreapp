USE [capstone]
GO

/****** Object:  Table [dbo].[Products]    Script Date: 12/11/2020 12:23:18 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](500) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[QuantityPerUnit] [varchar](50) NULL,
	[CategoryId] [int] NOT NULL,
	[StoreId] [int] NOT NULL,
	[Available] [int] NULL,
	[UserId] [int] NULL,
	[Store] [int] NULL
	)
GO


