USE [capstone]
GO

/****** Object:  Table [dbo].[Stocks]    Script Date: 12/11/2020 12:21:37 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Stocks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[TotalStocks] [int] NOT NULL,
	[UserId] [int] NULL,
	[Store] [int] NULL
)
GO


