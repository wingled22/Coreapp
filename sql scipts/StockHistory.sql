USE [capstone]
GO

/****** Object:  Table [dbo].[StocksHistory]    Script Date: 12/11/2020 12:19:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[StocksHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StockId] [int] NULL,
	[AddedStocks] [int] NULL,
	[DateAdded] [datetime] NULL,
	[UserId] [int] NULL,
	[Store] [int] NULL
 )
GO


