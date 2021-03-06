USE [E10Pilot]
GO
/****** Object:  Table [Ice].[Custom_Menu]    Script Date: 5/7/2015 9:08:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Ice].[Custom_Menu](
	[RowID] [bigint] IDENTITY(1,1) NOT NULL,
	[Company] [nvarchar](8) NULL,
	[MenuID] [nvarchar](30) NOT NULL,
	[MenuDesc] [nvarchar](40) NOT NULL,
	[ParentMenuID] [nvarchar](30) NOT NULL,
	[Sequence] [int] NOT NULL,
	[NameSpace] [nvarchar](100) NOT NULL,
	[Program] [nvarchar](500) NOT NULL,
	[Enabled] [bit] NOT NULL,
	[SecCode] [nvarchar](70) NULL,
	[Module] [nvarchar](3) NULL,
	[Comment] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [Ice].[Custom_Menu] ON 

GO
INSERT [Ice].[Custom_Menu] ([RowID], [Company], [MenuID], [MenuDesc], [ParentMenuID], [Sequence], [NameSpace], [Program], [Enabled], [SecCode], [Module], [Comment]) VALUES (1, NULL, N'COS001', N'Cost Management', N'', 1, N'Erp.Custom.UI.Common', N'Menu', 1, NULL, NULL, NULL)
GO
INSERT [Ice].[Custom_Menu] ([RowID], [Company], [MenuID], [MenuDesc], [ParentMenuID], [Sequence], [NameSpace], [Program], [Enabled], [SecCode], [Module], [Comment]) VALUES (3, NULL, N'COS002', N'Cost Requestion', N'COS001', 1, N'Erp.Custom.UI.Common', N'Menu', 1, NULL, NULL, NULL)
GO
INSERT [Ice].[Custom_Menu] ([RowID], [Company], [MenuID], [MenuDesc], [ParentMenuID], [Sequence], [NameSpace], [Program], [Enabled], [SecCode], [Module], [Comment]) VALUES (5, NULL, N'COS003', N'Review Requestion', N'COS005', 1, N'Erp.Custom.UI.Common', N'List', 1, N'SaleQuote.MarkUpPrice', NULL, NULL)
GO
INSERT [Ice].[Custom_Menu] ([RowID], [Company], [MenuID], [MenuDesc], [ParentMenuID], [Sequence], [NameSpace], [Program], [Enabled], [SecCode], [Module], [Comment]) VALUES (7, NULL, N'COS004', N'Sale', N'', 2, N'Erp.Custom.UI.Common', N'Menu', 1, NULL, NULL, NULL)
GO
INSERT [Ice].[Custom_Menu] ([RowID], [Company], [MenuID], [MenuDesc], [ParentMenuID], [Sequence], [NameSpace], [Program], [Enabled], [SecCode], [Module], [Comment]) VALUES (8, NULL, N'COS005', N'Mark-up Price', N'COS004', 3, N'Erp.Custom.UI.Common', N'Menu', 1, NULL, NULL, NULL)
GO
INSERT [Ice].[Custom_Menu] ([RowID], [Company], [MenuID], [MenuDesc], [ParentMenuID], [Sequence], [NameSpace], [Program], [Enabled], [SecCode], [Module], [Comment]) VALUES (9, NULL, N'COS006', N'Requestion Entry', N'COS002', 1, N'Erp.Custom.UI.Common', N'List', 1, N'CostManagement.CostRequest', NULL, NULL)
GO
INSERT [Ice].[Custom_Menu] ([RowID], [Company], [MenuID], [MenuDesc], [ParentMenuID], [Sequence], [NameSpace], [Program], [Enabled], [SecCode], [Module], [Comment]) VALUES (11, NULL, N'COS007', N'Requestion Tracker', N'COS002', 2, N'Erp.Custom.UI.Common', N'List', 0, N'CostManagement.CostRequest', NULL, NULL)
GO
INSERT [Ice].[Custom_Menu] ([RowID], [Company], [MenuID], [MenuDesc], [ParentMenuID], [Sequence], [NameSpace], [Program], [Enabled], [SecCode], [Module], [Comment]) VALUES (13, NULL, N'COS008', N'Requesition Approval', N'COS002', 3, N'Erp.Custom.UI.Common', N'List', 1, N'CostManagement.ApproveReq', NULL, NULL)
GO
SET IDENTITY_INSERT [Ice].[Custom_Menu] OFF
GO
