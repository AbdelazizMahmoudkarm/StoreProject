USE [Elphateh]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 1/8/2021 9:12:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 1/8/2021 9:12:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 1/8/2021 9:12:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 1/8/2021 9:12:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 1/8/2021 9:12:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 1/8/2021 9:12:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 1/8/2021 9:12:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 1/8/2021 9:12:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bills]    Script Date: 1/8/2021 9:12:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bills](
	[billId] [int] NOT NULL,
	[customerId] [int] NOT NULL,
	[dept] [float] NOT NULL,
	[hasMoney] [float] NOT NULL,
	[paid] [float] NOT NULL,
	[totalPrice] [float] NOT NULL,
	[date] [nvarchar](max) NULL,
	[discard] [bit] NOT NULL,
	[buy] [bit] NOT NULL,
	[discount] [float] NOT NULL,
	[userId] [nvarchar](max) NOT NULL,
	[isdel] [bit] NULL,
 CONSTRAINT [PK_Bills] PRIMARY KEY CLUSTERED 
(
	[billId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Colors]    Script Date: 1/8/2021 9:12:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Colors](
	[colorId] [int] IDENTITY(1,1) NOT NULL,
	[ColorName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Colors] PRIMARY KEY CLUSTERED 
(
	[colorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 1/8/2021 9:12:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[customerId] [int] NOT NULL,
	[name] [nvarchar](max) NULL,
	[phoneNumber] [nvarchar](max) NULL,
	[custMoney] [float] NOT NULL,
	[storMoney] [float] NOT NULL,
	[iscust] [bit] NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[customerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Discardeds]    Script Date: 1/8/2021 9:12:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Discardeds](
	[billId] [int] NOT NULL,
	[ItemId] [int] NOT NULL,
	[measureId] [int] NOT NULL,
	[colorId] [int] NOT NULL,
	[itemName] [nvarchar](max) NULL,
	[quantity] [float] NOT NULL,
	[price] [float] NOT NULL,
	[id] [int] NULL,
	[iscartona] [bit] NULL,
	[discardId] [int] NOT NULL,
	[purchaseId] [int] NULL,
 CONSTRAINT [PK_Discardeds] PRIMARY KEY CLUSTERED 
(
	[discardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemDetails]    Script Date: 1/8/2021 9:12:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemDetails](
	[itemDetailsId] [int] IDENTITY(1,1) NOT NULL,
	[measurementId] [int] NOT NULL,
	[itemId] [int] NOT NULL,
	[colorId] [int] NOT NULL,
	[Quantity] [float] NOT NULL,
	[priceSale] [float] NOT NULL,
	[priceBuy] [float] NOT NULL,
	[cartona] [float] NOT NULL,
	[isdel] [bit] NULL,
 CONSTRAINT [PK_ItemDetails] PRIMARY KEY CLUSTERED 
(
	[itemDetailsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Items]    Script Date: 1/8/2021 9:12:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Items](
	[itemId] [int] IDENTITY(1,1) NOT NULL,
	[itemName] [nvarchar](max) NULL,
	[storeId] [int] NOT NULL,
	[isdel] [bit] NULL,
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
	[itemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Masroufats]    Script Date: 1/8/2021 9:12:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Masroufats](
	[Id] [int] NOT NULL,
	[ways] [nvarchar](max) NULL,
	[paid] [float] NULL,
	[date] [nvarchar](max) NULL,
 CONSTRAINT [PK_Masroufats] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Measurements]    Script Date: 1/8/2021 9:12:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Measurements](
	[measurementId] [int] IDENTITY(1,1) NOT NULL,
	[measurementName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Measurements] PRIMARY KEY CLUSTERED 
(
	[measurementId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Measureperiorities]    Script Date: 1/8/2021 9:12:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Measureperiorities](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[measureid] [int] NULL,
	[periority] [int] NULL,
 CONSTRAINT [PK__Measurep__3213E83F266D9784] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 1/8/2021 9:12:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[paymentId] [int] NOT NULL,
	[customerId] [int] NOT NULL,
	[paid] [float] NOT NULL,
	[date] [nvarchar](max) NULL,
	[billId] [int] NULL,
 CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED 
(
	[paymentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Purchases]    Script Date: 1/8/2021 9:12:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Purchases](
	[billId] [int] NOT NULL,
	[itemId] [int] NOT NULL,
	[measureId] [int] NOT NULL,
	[colorId] [int] NOT NULL,
	[itemName] [nvarchar](max) NULL,
	[itemDetailsId] [int] NULL,
	[quantity] [float] NOT NULL,
	[price] [float] NOT NULL,
	[saleprice] [float] NOT NULL,
	[id] [int] NULL,
	[iscartona] [bit] NULL,
	[purchaseid] [int] NOT NULL,
	[isdel] [bit] NULL,
 CONSTRAINT [PK_Purchases_1] PRIMARY KEY CLUSTERED 
(
	[purchaseid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stores]    Script Date: 1/8/2021 9:12:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stores](
	[storeId] [int] IDENTITY(1,1) NOT NULL,
	[storeName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Stores] PRIMARY KEY CLUSTERED 
(
	[storeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'1a44653c-918c-43b2-90bd-fd55775f0ebc', N'Admin', N'ADMIN', N'3a4077ec-1ab1-40d2-9864-9f7b80bf9c05')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'bfd7825e-2d7a-4940-b08a-f45835c6e6ad', N'User', N'USER', N'ead5de15-5cbd-47ab-b13a-a0b90189a186')
SET IDENTITY_INSERT [dbo].[Colors] ON 

INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (1, N'عادي')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (2, N'احمر')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (3, N'نبيتي')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (4, N'بني')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (5, N'ازرق')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (6, N'موف')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (7, N'اخضر')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (8, N'ذهبي')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (9, N'فضي')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (10, N'اسود')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (11, N'210')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (12, N'211')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (13, N'212')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (14, N'213')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (15, N'214')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (16, N'215')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (17, N'216')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (18, N'217')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (19, N'218')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (20, N'219')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (21, N'220')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (22, N'221')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (23, N'222')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (24, N'223')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (25, N'224')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (26, N'303')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (27, N'304')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (28, N'305')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (29, N'306')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (30, N'301')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (31, N'302')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (32, N'307')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (33, N'503')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (34, N'504')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (35, N'نحاسي')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (36, N'307')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (37, N'ابيض')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (38, N'شفاف')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (39, N'04')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (40, N'06')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (41, N'07')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (42, N'019')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (43, N'012')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (44, N'احمر 603')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (45, N'اخضر فاتح 601')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (46, N'اصفر فاوه 611')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (47, N'اصفر ليموني 606')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (48, N'اسود608')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (49, N'ازرق 602')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (50, N'نبيتي 604')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (51, N'بني 610')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (52, N'موف 613')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (53, N'رمادي')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (54, N'ارونج607')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (55, N'اصفر')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (56, N'مط')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (57, N'نصف لامع')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (58, N'لامع')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (59, N'221')
INSERT [dbo].[Colors] ([colorId], [ColorName]) VALUES (60, N'عسلي')
SET IDENTITY_INSERT [dbo].[Colors] OFF
SET IDENTITY_INSERT [dbo].[ItemDetails] ON 

INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (218, 6, 119, 9, 9, 30, 13.6, 12, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (219, 14, 120, 1, 2, 150, 115, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (220, 14, 121, 1, 2, 90, 60, 0, 1)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (221, 14, 122, 1, 8, 10, 7.5, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (222, 14, 123, 1, 12, 25, 15.83, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (223, 14, 124, 1, 12, 10, 6.25, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (224, 14, 125, 1, 1, 15, 10, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (225, 14, 126, 1, 2, 20, 16, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (226, 14, 127, 1, 4, 10, 5, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (227, 14, 128, 1, 6, 10, 6, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (228, 14, 129, 1, 2, 100, 65, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (229, 14, 130, 1, 7, 10, 7.5, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (230, 14, 131, 1, 6, 10, 5, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (231, 14, 132, 1, 3, 15, 12, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (232, 14, 133, 1, 1, 25, 21, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (233, 14, 134, 1, 5, 5, 2.5, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (234, 14, 135, 1, 4, 5, 3, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (235, 14, 136, 1, 2, 25, 20, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (236, 22, 137, 1, 8, 8, 4.5, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (237, 23, 137, 1, 3, 10, 6, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (238, 24, 137, 1, 5, 15, 8, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (239, 25, 138, 1, 24, 7, 4.6, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (240, 8, 139, 1, 6, 55, 52, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (241, 2, 140, 38, 1, 265, 254, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (242, 17, 55, 37, 0, 200, 191.4, 0, 1)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (243, 1, 1, 37, 0, 440, 432.5, 0, 1)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (244, 2, 1, 37, 0, 135, 132.5, 4, 1)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (245, 2, 14, 37, 7, 120, 112.66, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (246, 1, 55, 37, 0, 160, 0, 0, 1)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (247, 1, 10, 1, 1, 100, 0, 0, 1)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (248, 2, 11, 1, 0, 75, 70.77, 4, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (249, 4, 5, 1, 9, 20, 18.75, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (250, 3, 142, 1, 5, 20, 18.83, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (251, 15, 71, 1, 11, 10, 6.19, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (252, 2, 143, 37, 0, 80, 72.34, 4, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (253, 2, 144, 60, 12, 80, 73.53, 4, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (254, 2, 145, 10, 7, 90, 83.32, 4, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (255, 2, 146, 37, 0, 120, 112.5, 4, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (256, 2, 147, 60, 11, 90, 83.32, 4, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (257, 19, 148, 38, 3.7600000000000002, 110, 90.48, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (258, 1, 149, 1, 0, 86, 85, 0, 1)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (260, 12, 11, 1, 0, 130, 125.96, 0, 1)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (261, 3, 152, 9, 138, 140, 72.25, 12, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (262, 3, 153, 9, 12, 100, 58, 12, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (263, 3, 154, 9, 14, 100, 55, 12, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (264, 3, 155, 9, 12, 110, 58, 12, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (265, 20, 83, 51, 109, 4, 3.6, 10, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (266, 20, 83, 48, 50, 4, 3.6, 10, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (267, 14, 156, 1, 6, 70, 62, 0, 1)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (268, 14, 157, 1, 6, 70, 62, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (269, 14, 158, 1, 10, 35, 27.5, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (270, 14, 159, 1, 10, 60, 49, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (271, 14, 160, 1, 12, 20, 12.92, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (272, 14, 161, 1, 10, 15, 10.417, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (273, 14, 162, 1, 5, 15, 12, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (274, 14, 163, 1, 5, 12, 9.5, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (275, 2, 143, 37, 2, 80, 68.555, 4, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (276, 12, 164, 37, 0, 125, 119.235, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (277, 3, 147, 60, 18, 30, 28.173, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (278, 3, 145, 10, 10, 30, 28.173, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (279, 2, 146, 37, 2, 120, 112.69, 4, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (280, 3, 146, 37, 12, 45, 39.871, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (281, 4, 165, 1, 0, 20, 15, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (282, 2, 61, 1, 2, 125, 121.95, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (283, 3, 113, 37, 4, 0, 39.75, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (284, 16, 54, 1, 28, 10, 7.0555, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (285, 3, 166, 46, 6, 30, 26.85, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (286, 1, 14, 1, 2, 400, 393, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (287, 12, 11, 37, 12, 130, 125, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (288, 10, 167, 1, 7, 15, 12.39, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (289, 1, 110, 37, 2, 285, 277, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (290, 2, 53, 1, 3, 30, 26, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (291, 3, 67, 38, 6, 45, 40, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (292, 26, 54, 1, 10, 3, 2.5, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (293, 27, 2, 60, 6, 135, 128.25, 4, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (294, 1, 10, 1, 6, 100, 94.5, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (295, 1, 55, 37, 6, 160, 148.5, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (296, 17, 55, 37, 6, 200, 190, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (297, 3, 68, 1, 6, 20, 17.5, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (298, 19, 168, 1, 0, 7.5, 7.5, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (299, 2, 169, 37, 1, 130, 123.195, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (300, 2, 74, 38, 4, 165, 161.1575, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (301, 12, 164, 37, 0, 130, 125.8225, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (302, 12, 170, 37, 4, 210, 197.745, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (303, 18, 55, 37, 4, 260, 255.5, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (304, 9, 13, 1, 68, 30, 25.25, 4, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (305, 9, 106, 1, 6, 75, 66, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (306, 3, 143, 37, 12, 30, 24.83, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (307, 2, 59, 1, 8, 160, 153, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (308, 3, 5, 1, 12, 35, 30.416, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (309, 11, 5, 1, 6, 60, 48.333, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (310, 15, 71, 1, 72, 10, 6.944, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (311, 3, 171, 1, 1.205, 160, 126, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (312, 2, 1, 37, 3, 135, 132, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (313, 2, 55, 37, 2, 50, 44, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (314, 2, 143, 37, 4, 80, 69.084, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (315, 9, 106, 1, 8, 75, 65.5, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (316, 28, 129, 1, 10, 80, 60, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (317, 29, 129, 1, 15, 70, 50, 0, 0)
GO
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (318, 29, 120, 1, 8, 115, 100, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (319, 15, 172, 1, 36, 10, 3.611, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (320, 16, 172, 1, 12, 15, 7.222, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (321, 20, 173, 1, 10, 35, 30, 0, 0)
INSERT [dbo].[ItemDetails] ([itemDetailsId], [measurementId], [itemId], [colorId], [Quantity], [priceSale], [priceBuy], [cartona], [isdel]) VALUES (322, 18, 55, 1, 5, 265, 260, 0, 0)
SET IDENTITY_INSERT [dbo].[ItemDetails] OFF
SET IDENTITY_INSERT [dbo].[Items] ON 

INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (1, N'بلاستيك جلتكس 25000 GLC', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (2, N'سوبر لاك 708 عسلي GLC', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (3, N'سوبر لاك 750 اسود GLC', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (4, N'سوبر لاك 721 ازرق GLC', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (5, N'معجون حديد توب ميدو', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (6, N'مط داي تون عسلي GLC', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (7, N'بلاستيك ميجا تكس كبير', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (10, N'سيلر مائي المقاوم 0017  GLC', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (11, N'مط داي-تون ابيض  GLC', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (12, N'سوبر لاك 708 عسلي العملاق GLC', 1, 1)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (13, N'تنر المهندس الدبابه ', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (14, N'بلاستك جلتكس 20000  GLC', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (15, N'c جلتكس 20000  بيز ', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (16, N'A جلتكس 20000  بيز', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (17, N'B جلتكس 20000  بيز', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (18, N'سوبر لاك 719 اخضر  0.820 لتر GLC', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (19, N'سوبر لاك 790 نبيتي غامق GLC', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (20, N'سوبر لاك 784 موف GLC', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (21, N'سوبر لاك ابيض  786   GLC', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (28, N'ميتالك', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (29, N'ميتالك عيار', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (33, N'(اطيفه (اوتوشندو ليزر', 1, 1)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (34, N'(اطيفه (سيناوي', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (35, N'(اطيفه (اوريوم', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (36, N'فلاش ليزر', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (37, N'شيراز', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (38, N'ماركو بولو', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (39, N'(روعه (سواحيلي ناعم', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (40, N'فلاور', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (41, N'مالتي كالر', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (42, N'خيال ', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (43, N'روستن', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (44, N'ايروز', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (47, N'(فلاور(لارما', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (48, N'(اوتوشندو(لارما', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (49, N'(ميتالك (لارما', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (50, N'(ماركوبولو(لارما', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (51, N'كراكليه', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (52, N'ستوكو', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (53, N'100 معجون داي-تون  GLC ', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (54, N'لذق ابوالعزم', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (55, N'بلاستيك 3030 GLC', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (56, N'حجر حف', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (57, N' GLC 150برايمر حديد ', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (58, N'GLC 690ورنيش استاندر ', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (59, N'سلير فاخر ميدو', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (60, N'GLCورنيش مط1001المركب ', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (61, N' GLCورنيش 901زجاجي المركب ', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (62, N'وفاW300 سيلر', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (63, N' بروتال لامع وفا', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (64, N'%ورنيش بروتال 45', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (65, N'Glc 900  معجون أكريلك   ', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (66, N'حصي جوز', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (67, N' GLC زيجزاج 303 ', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (68, N'غراء بنتا', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (69, N'بطاين قماش', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (71, N'لذق دوبل', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (72, N'جرايد', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (73, N'(جرايد (ملزمه', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (74, N'بوليستر كابسي', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (75, N'بوليستر وفا', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (76, N' احمرGlcسوبر لاك715 ', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (77, N'جملكه حمراء', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (78, N'دكو ايجكو', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (79, N'ورنيش مط ايجكو', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (80, N'بوليستر ايجكو', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (81, N'صبغه كابسي', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (82, N'فلير ايجكو سريع', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (83, N' GLCتلوينه ', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (84, N'صبغه وفا', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (85, N'دهبي 3000 بودره', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (86, N'فضي3000 بودره', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (87, N'نحاسي10000بودره', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (88, N'تكس', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (89, N' GLC معجون شروخ ', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (90, N'سنفره كوري 150', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (91, N'سنفره كوري 220', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (92, N'120سنفره كوره اسود', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (93, N'سنفره كوري 120', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (94, N'سنفره الصقر 80', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (95, N'سنفره الصقر 150', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (96, N'نفط موبيك', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (97, N'سبيرتو احمر', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (98, N'غره خرز', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (99, N'اكسيد احمر', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (100, N'اكسيد بني', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (101, N'اكسيد اصفر', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (102, N'زنك السلاب نمره 1', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (103, N'عود استيل', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (104, N'ورنيش سوفت تاتش', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (105, N'همر فنش', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (106, N'تنر الصاروخين', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (107, N'Aسوبر بلاتين 7000 بيز ', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (108, N'Bسوبر بلاتين 7000 بيز', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (109, N'Cسوبر بلاتين 7000 بيز ', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (110, N'بلاستك 7070', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (111, N'Aسوبر لاك بيز', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (112, N' Bسوبر لاك بيز ', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (113, N' Cسوبر لاك بيز', 1, 0)
GO
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (114, N'سلير مائي كابسي', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (115, N'برلاتو مطاطي', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (116, N'برلاتو', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (118, N'عيار بلاس', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (119, N'سواريه', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (120, N'تابلوه 5 قطعه', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (121, N'تابلوه 3 قطعه 8ملي', 1, 1)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (122, N'كف عادي', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (123, N'كف استالس', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (124, N'سيكنه عادي', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (125, N'طقم فرشه قلم', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (126, N'فرشه روعه', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (127, N'طقم صولب عاده', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (128, N'شاسيه كبير', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (129, N'تابلوه 3 قطعه ', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (130, N'غيار روله كبير', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (131, N'باغه فلاور', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (132, N'ملاك بلاستك', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (133, N'سكينه استالس', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (134, N'شاسيه روله صغيره', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (135, N'غيار روله صغيره', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (136, N'طاقم صولب استالس', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (137, N'فرشه', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (138, N'شاش', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (139, N'معجون ممتاز', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (140, N'ورنيش بروتال المهندس', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (142, N'مط داي تون اسود 750GLC', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (143, N' لاكيه مط ابيض كابسي', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (144, N' لاكيه مط عسلي كابسي', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (145, N' لاكيه لامع اسود كابسي 392', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (146, N' لاكيه لامع ابيض كابسي', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (147, N' لاكيه لامع عسلي كابسي 630', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (148, N' مصلب لاتيكو ', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (149, N'سلير الفا', 1, 1)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (152, N'(اطيفه (كلاسيكو', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (153, N'(اوتوشندو(لارما ليزر', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (154, N'Brimo اطيفه ', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (155, N'Brimo اطيفه ليزر', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (156, N'سيكنه 6بوصه ابانوس', 1, 1)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (157, N' سكينه 6بوصه ابانوس', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (158, N' روله تركي 23 سم اخضر', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (159, N' روله تركي بروخش اصفر', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (160, N' فرشه 2.5 بوصه ابداع', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (161, N' فرشه 2بوصه ابداع', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (162, N' قلم رسم طبيعي', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (163, N' قلم 6 فرشه', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (164, N' لاكيه مط ابيض كابسي هاتريك', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (165, N'لاكيه لامع كابسي 230 اصفر فاوه', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (166, N' سوبر لاك 791 اصفر جملي GLC', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (167, N' لذق السويدي', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (168, N'بنزين', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (169, N' بوليستر  كابسي 3.25كجم ', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (170, N'لاكيه لامع ابيض كابسي هاتريك', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (171, N'سنفره كوري 180', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (172, N'لذق اللبنانيه', 1, 0)
INSERT [dbo].[Items] ([itemId], [itemName], [storeId], [isdel]) VALUES (173, N'لذق ورق حائط', 1, 0)
SET IDENTITY_INSERT [dbo].[Items] OFF
SET IDENTITY_INSERT [dbo].[Measurements] ON 

INSERT [dbo].[Measurements] ([measurementId], [measurementName]) VALUES (1, N'بستله')
INSERT [dbo].[Measurements] ([measurementId], [measurementName]) VALUES (2, N' جالون ')
INSERT [dbo].[Measurements] ([measurementId], [measurementName]) VALUES (3, N'كيلو')
INSERT [dbo].[Measurements] ([measurementId], [measurementName]) VALUES (4, N'نص')
INSERT [dbo].[Measurements] ([measurementId], [measurementName]) VALUES (5, N'كرتونه')
INSERT [dbo].[Measurements] ([measurementId], [measurementName]) VALUES (6, N'ربع')
INSERT [dbo].[Measurements] ([measurementId], [measurementName]) VALUES (7, N'1/8')
INSERT [dbo].[Measurements] ([measurementId], [measurementName]) VALUES (8, N'شيكاره')
INSERT [dbo].[Measurements] ([measurementId], [measurementName]) VALUES (9, N'جركن')
INSERT [dbo].[Measurements] ([measurementId], [measurementName]) VALUES (10, N'بكره')
INSERT [dbo].[Measurements] ([measurementId], [measurementName]) VALUES (11, N'2كيلو')
INSERT [dbo].[Measurements] ([measurementId], [measurementName]) VALUES (12, N'جالون دوبل')
INSERT [dbo].[Measurements] ([measurementId], [measurementName]) VALUES (14, N'قطعه')
INSERT [dbo].[Measurements] ([measurementId], [measurementName]) VALUES (15, N'2.5 سم ')
INSERT [dbo].[Measurements] ([measurementId], [measurementName]) VALUES (16, N'5 سم')
INSERT [dbo].[Measurements] ([measurementId], [measurementName]) VALUES (17, N'بستله دوبل')
INSERT [dbo].[Measurements] ([measurementId], [measurementName]) VALUES (18, N'بستله عملاق')
INSERT [dbo].[Measurements] ([measurementId], [measurementName]) VALUES (19, N'لتر')
INSERT [dbo].[Measurements] ([measurementId], [measurementName]) VALUES (20, N'علبه')
INSERT [dbo].[Measurements] ([measurementId], [measurementName]) VALUES (21, N'عود')
INSERT [dbo].[Measurements] ([measurementId], [measurementName]) VALUES (22, N'1.5 بوصه')
INSERT [dbo].[Measurements] ([measurementId], [measurementName]) VALUES (23, N'2 بوصه')
INSERT [dbo].[Measurements] ([measurementId], [measurementName]) VALUES (24, N'2.5 بوصه')
INSERT [dbo].[Measurements] ([measurementId], [measurementName]) VALUES (25, N'متر')
INSERT [dbo].[Measurements] ([measurementId], [measurementName]) VALUES (26, N'1سم')
INSERT [dbo].[Measurements] ([measurementId], [measurementName]) VALUES (27, N'جالون المعملاق')
INSERT [dbo].[Measurements] ([measurementId], [measurementName]) VALUES (28, N'8ملي')
INSERT [dbo].[Measurements] ([measurementId], [measurementName]) VALUES (29, N'6ملي')
SET IDENTITY_INSERT [dbo].[Measurements] OFF
SET IDENTITY_INSERT [dbo].[Measureperiorities] ON 

INSERT [dbo].[Measureperiorities] ([id], [measureid], [periority]) VALUES (1, 5, 0)
INSERT [dbo].[Measureperiorities] ([id], [measureid], [periority]) VALUES (2, 2, 1)
INSERT [dbo].[Measureperiorities] ([id], [measureid], [periority]) VALUES (3, 3, 1)
INSERT [dbo].[Measureperiorities] ([id], [measureid], [periority]) VALUES (4, 4, 1)
INSERT [dbo].[Measureperiorities] ([id], [measureid], [periority]) VALUES (5, 6, 1)
INSERT [dbo].[Measureperiorities] ([id], [measureid], [periority]) VALUES (6, 7, 1)
INSERT [dbo].[Measureperiorities] ([id], [measureid], [periority]) VALUES (7, 9, 1)
INSERT [dbo].[Measureperiorities] ([id], [measureid], [periority]) VALUES (8, 10, 1)
INSERT [dbo].[Measureperiorities] ([id], [measureid], [periority]) VALUES (9, 11, 1)
INSERT [dbo].[Measureperiorities] ([id], [measureid], [periority]) VALUES (10, 14, 1)
INSERT [dbo].[Measureperiorities] ([id], [measureid], [periority]) VALUES (11, 15, 1)
INSERT [dbo].[Measureperiorities] ([id], [measureid], [periority]) VALUES (12, 16, 1)
INSERT [dbo].[Measureperiorities] ([id], [measureid], [periority]) VALUES (13, 19, 1)
SET IDENTITY_INSERT [dbo].[Measureperiorities] OFF
SET IDENTITY_INSERT [dbo].[Stores] ON 

INSERT [dbo].[Stores] ([storeId], [storeName]) VALUES (1, N'المخزن الرئيسي')
SET IDENTITY_INSERT [dbo].[Stores] OFF
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Bills]  WITH CHECK ADD  CONSTRAINT [FK_Bills_Customers_customerId] FOREIGN KEY([customerId])
REFERENCES [dbo].[Customers] ([customerId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Bills] CHECK CONSTRAINT [FK_Bills_Customers_customerId]
GO
ALTER TABLE [dbo].[Discardeds]  WITH CHECK ADD  CONSTRAINT [FK_Discardeds_Bills_billId] FOREIGN KEY([billId])
REFERENCES [dbo].[Bills] ([billId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Discardeds] CHECK CONSTRAINT [FK_Discardeds_Bills_billId]
GO
ALTER TABLE [dbo].[Discardeds]  WITH CHECK ADD  CONSTRAINT [FK_Discardeds_Colors_colorId] FOREIGN KEY([colorId])
REFERENCES [dbo].[Colors] ([colorId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Discardeds] CHECK CONSTRAINT [FK_Discardeds_Colors_colorId]
GO
ALTER TABLE [dbo].[Discardeds]  WITH CHECK ADD  CONSTRAINT [FK_Discardeds_Items_ItemId] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Items] ([itemId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Discardeds] CHECK CONSTRAINT [FK_Discardeds_Items_ItemId]
GO
ALTER TABLE [dbo].[Discardeds]  WITH CHECK ADD  CONSTRAINT [FK_Discardeds_Measurements_measureId] FOREIGN KEY([measureId])
REFERENCES [dbo].[Measurements] ([measurementId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Discardeds] CHECK CONSTRAINT [FK_Discardeds_Measurements_measureId]
GO
ALTER TABLE [dbo].[ItemDetails]  WITH CHECK ADD  CONSTRAINT [FK_ItemDetails_Colors_colorId] FOREIGN KEY([colorId])
REFERENCES [dbo].[Colors] ([colorId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ItemDetails] CHECK CONSTRAINT [FK_ItemDetails_Colors_colorId]
GO
ALTER TABLE [dbo].[ItemDetails]  WITH CHECK ADD  CONSTRAINT [FK_ItemDetails_Items_itemId] FOREIGN KEY([itemId])
REFERENCES [dbo].[Items] ([itemId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ItemDetails] CHECK CONSTRAINT [FK_ItemDetails_Items_itemId]
GO
ALTER TABLE [dbo].[ItemDetails]  WITH CHECK ADD  CONSTRAINT [FK_ItemDetails_Measurements_measurementId] FOREIGN KEY([measurementId])
REFERENCES [dbo].[Measurements] ([measurementId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ItemDetails] CHECK CONSTRAINT [FK_ItemDetails_Measurements_measurementId]
GO
ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_Items_Stores_storeId] FOREIGN KEY([storeId])
REFERENCES [dbo].[Stores] ([storeId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_Items_Stores_storeId]
GO
ALTER TABLE [dbo].[Measureperiorities]  WITH CHECK ADD  CONSTRAINT [FK__Measurepe__measu__6FE99F9F] FOREIGN KEY([measureid])
REFERENCES [dbo].[Measurements] ([measurementId])
GO
ALTER TABLE [dbo].[Measureperiorities] CHECK CONSTRAINT [FK__Measurepe__measu__6FE99F9F]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [FK__Payments__billId__2739D489] FOREIGN KEY([billId])
REFERENCES [dbo].[Bills] ([billId])
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [FK__Payments__billId__2739D489]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [FK_Payments_Customers_customerId] FOREIGN KEY([customerId])
REFERENCES [dbo].[Customers] ([customerId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [FK_Payments_Customers_customerId]
GO
ALTER TABLE [dbo].[Purchases]  WITH CHECK ADD  CONSTRAINT [FK_Purchases_Bills_billId] FOREIGN KEY([billId])
REFERENCES [dbo].[Bills] ([billId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Purchases] CHECK CONSTRAINT [FK_Purchases_Bills_billId]
GO
ALTER TABLE [dbo].[Purchases]  WITH CHECK ADD  CONSTRAINT [FK_Purchases_Colors_colorId] FOREIGN KEY([colorId])
REFERENCES [dbo].[Colors] ([colorId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Purchases] CHECK CONSTRAINT [FK_Purchases_Colors_colorId]
GO
ALTER TABLE [dbo].[Purchases]  WITH CHECK ADD  CONSTRAINT [FK_Purchases_ItemDetails_itemDetailsId] FOREIGN KEY([itemDetailsId])
REFERENCES [dbo].[ItemDetails] ([itemDetailsId])
GO
ALTER TABLE [dbo].[Purchases] CHECK CONSTRAINT [FK_Purchases_ItemDetails_itemDetailsId]
GO
ALTER TABLE [dbo].[Purchases]  WITH CHECK ADD  CONSTRAINT [FK_Purchases_Items_itemId] FOREIGN KEY([itemId])
REFERENCES [dbo].[Items] ([itemId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Purchases] CHECK CONSTRAINT [FK_Purchases_Items_itemId]
GO
ALTER TABLE [dbo].[Purchases]  WITH CHECK ADD  CONSTRAINT [FK_Purchases_Measurements_measureId] FOREIGN KEY([measureId])
REFERENCES [dbo].[Measurements] ([measurementId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Purchases] CHECK CONSTRAINT [FK_Purchases_Measurements_measureId]
GO
