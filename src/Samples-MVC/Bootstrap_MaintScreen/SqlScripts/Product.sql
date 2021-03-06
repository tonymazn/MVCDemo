USE [Sandbox]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 1/7/2015 7:53:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Product](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [varchar](50) NOT NULL,
	[IntroductionDate] [datetime] NULL,
	[Cost] [money] NULL,
	[Price] [money] NULL,
	[IsDiscontinued] [bit] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

GO
INSERT [dbo].[Product] ([ProductId], [ProductName], [IntroductionDate], [Cost], [Price], [IsDiscontinued]) VALUES (1, N'Productivity Framework', NULL, 100.0000, 5000.0000, 0)
GO
INSERT [dbo].[Product] ([ProductId], [ProductName], [IntroductionDate], [Cost], [Price], [IsDiscontinued]) VALUES (2, N'Architecting ASP.NET eBook', CAST(N'2009-04-05 00:00:00.000' AS DateTime), NULL, 20.0000, 1)
GO
INSERT [dbo].[Product] ([ProductId], [ProductName], [IntroductionDate], [Cost], [Price], [IsDiscontinued]) VALUES (3, N'Introduction to N-Tier Book', CAST(N'2006-06-04 00:00:00.000' AS DateTime), 2.0000, NULL, 0)
GO
INSERT [dbo].[Product] ([ProductId], [ProductName], [IntroductionDate], [Cost], [Price], [IsDiscontinued]) VALUES (4, N'Security for ASP.NET Developers eBook', CAST(N'2002-08-25 00:00:00.000' AS DateTime), 2.0000, 20.0000, NULL)
GO
INSERT [dbo].[Product] ([ProductId], [ProductName], [IntroductionDate], [Cost], [Price], [IsDiscontinued]) VALUES (5, N'Agile ALM', CAST(N'2002-03-03 00:00:00.000' AS DateTime), 100.0000, 5000.0000, 1)
GO
INSERT [dbo].[Product] ([ProductId], [ProductName], [IntroductionDate], [Cost], [Price], [IsDiscontinued]) VALUES (6, N'VB.NET Fundamentals eBook', CAST(N'2004-05-27 00:00:00.000' AS DateTime), 2.0000, 20.0000, 0)
GO
INSERT [dbo].[Product] ([ProductId], [ProductName], [IntroductionDate], [Cost], [Price], [IsDiscontinued]) VALUES (7, N'Introduction to SQL Server 2008', CAST(N'2005-01-11 00:00:00.000' AS DateTime), 2.0000, 20.0000, 1)
GO
INSERT [dbo].[Product] ([ProductId], [ProductName], [IntroductionDate], [Cost], [Price], [IsDiscontinued]) VALUES (8, N'Developer Utilities', CAST(N'2005-05-02 00:00:00.000' AS DateTime), 2.0000, 39.9500, 1)
GO
INSERT [dbo].[Product] ([ProductId], [ProductName], [IntroductionDate], [Cost], [Price], [IsDiscontinued]) VALUES (58, N'A New Product', CAST(N'2014-06-25 07:28:51.293' AS DateTime), 10.0000, 20.0000, 0)
GO
INSERT [dbo].[Product] ([ProductId], [ProductName], [IntroductionDate], [Cost], [Price], [IsDiscontinued]) VALUES (10, N'Web Authoring System', CAST(N'2003-04-12 00:00:00.000' AS DateTime), 100.0000, 5000.0000, 0)
GO
INSERT [dbo].[Product] ([ProductId], [ProductName], [IntroductionDate], [Cost], [Price], [IsDiscontinued]) VALUES (46, N'Gretsch Catalina Drums', CAST(N'2009-01-01 00:00:00.000' AS DateTime), 310.0000, 798.6000, 1)
GO
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
/****** Object:  Index [PK__Product]    Script Date: 1/7/2015 7:53:01 AM ******/
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [PK__Product] PRIMARY KEY NONCLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
