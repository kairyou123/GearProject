USE [Gear]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 2020/12/13 18:35:18 ******/
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
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 2020/12/13 18:35:18 ******/
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
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 2020/12/13 18:35:18 ******/
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
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 2020/12/13 18:35:18 ******/
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
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 2020/12/13 18:35:18 ******/
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
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 2020/12/13 18:35:18 ******/
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
	[HoTen] [nvarchar](max) NULL,
	[DiaChi] [nvarchar](max) NULL,
	[GioiTinh] [nvarchar](max) NULL,
	[CMND] [nvarchar](max) NULL,
	[isDelete] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 2020/12/13 18:35:18 ******/
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
/****** Object:  Table [dbo].[ChiTietHDs]    Script Date: 2020/12/13 18:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHDs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LinhKienId] [int] NOT NULL,
	[HoaDonId] [int] NOT NULL,
	[SoLuongBan] [decimal](10, 0) NOT NULL,
	[DonGia] [decimal](12, 0) NOT NULL,
 CONSTRAINT [PK_ChiTietHDs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CTGiaos]    Script Date: 2020/12/13 18:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTGiaos](
	[LinhKienId] [int] NOT NULL,
	[HDNhapId] [int] NOT NULL,
	[SoLuong] [int] NOT NULL,
	[DonGia] [decimal](12, 0) NOT NULL,
 CONSTRAINT [PK_CTGiaos] PRIMARY KEY CLUSTERED 
(
	[HDNhapId] ASC,
	[LinhKienId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonGias]    Script Date: 2020/12/13 18:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonGias](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ngay] [datetime2](7) NOT NULL,
	[DonGiaBan] [decimal](12, 0) NOT NULL,
	[GiamGia] [int] NOT NULL,
	[ApDung] [bit] NOT NULL,
	[LinhKienId] [int] NOT NULL,
 CONSTRAINT [PK_DonGias] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GioHangs]    Script Date: 2020/12/13 18:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GioHangs](
	[UserId] [nvarchar](450) NOT NULL,
	[LinhKienId] [int] NOT NULL,
	[SoLuong] [int] NOT NULL,
 CONSTRAINT [PK_GioHangs] PRIMARY KEY CLUSTERED 
(
	[LinhKienId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDonNhapHangs]    Script Date: 2020/12/13 18:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDonNhapHangs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MaHD] [nvarchar](100) NOT NULL,
	[NgayLapHD] [datetime2](7) NOT NULL,
	[NgayGiao] [datetime2](7) NOT NULL,
	[NCCId] [int] NOT NULL,
	[isDelete] [int] NOT NULL,
 CONSTRAINT [PK_HoaDonNhapHangs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDons]    Script Date: 2020/12/13 18:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDons](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MaHD] [nvarchar](100) NOT NULL,
	[NgayLapHD] [datetime2](7) NOT NULL,
	[NgayGiao] [datetime2](7) NULL,
	[TiGia] [decimal](18, 0) NOT NULL,
	[UserId] [nvarchar](450) NULL,
	[PhuongThucThanhToan] [nvarchar](max) NULL,
	[TinhTrang] [nvarchar](max) NULL,
 CONSTRAINT [PK_HoaDons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LinhKiens]    Script Date: 2020/12/13 18:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LinhKiens](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MaLK] [nvarchar](100) NOT NULL,
	[TenLK] [nvarchar](100) NOT NULL,
	[MoTa] [ntext] NOT NULL,
	[TGBH] [smallint] NOT NULL,
	[NgayCapNhat] [datetime2](7) NOT NULL,
	[Hinh] [nvarchar](100) NOT NULL,
	[LoaiId] [int] NOT NULL,
	[NCCId] [int] NOT NULL,
	[SLTonKho] [int] NOT NULL,
	[DaBan] [int] NOT NULL,
	[isDelete] [int] NOT NULL,
 CONSTRAINT [PK_LinhKiens] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiLinhKiens]    Script Date: 2020/12/13 18:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiLinhKiens](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MaLoai] [nvarchar](100) NOT NULL,
	[Ten] [nvarchar](100) NOT NULL,
	[isDelete] [int] NOT NULL,
 CONSTRAINT [PK_LoaiLinhKiens] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaCungCaps]    Script Date: 2020/12/13 18:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaCungCaps](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MaNCC] [nvarchar](100) NOT NULL,
	[TenNCC] [nvarchar](100) NOT NULL,
	[MoTa] [nvarchar](max) NULL,
	[isDelete] [int] NOT NULL,
 CONSTRAINT [PK_NhaCungCaps] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'370b1644-bc01-4cd5-9d69-9e474d455139', N'Khách hàng', N'KHÁCH HÀNG', N'ae8f7026-36ad-4d8c-a3b8-956dc5ce7e99')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'df2fb367-6c1f-415c-802d-63ed6ab3d9d8', N'Quản lý', N'QUẢN LÝ', N'fccb0a41-0193-4649-a2fb-2b178f316954')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'ffea4dfe-b314-4063-bce6-af891698d95f', N'Admin', N'ADMIN', N'481ec2f6-5600-4d2f-bdca-a159ac10c372')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'70f7926b-c6be-4a58-8001-66e52438e0c9', N'370b1644-bc01-4cd5-9d69-9e474d455139')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e3c3c93a-de9b-49d2-ab03-3ffbe7a6d78f', N'ffea4dfe-b314-4063-bce6-af891698d95f')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [HoTen], [DiaChi], [GioiTinh], [CMND], [isDelete]) VALUES (N'70f7926b-c6be-4a58-8001-66e52438e0c9', N'bob@gmail.com', N'BOB@GMAIL.COM', N'bob@gmail.com', N'BOB@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEJVjfO40V2gnFg3s34tzcCoSXymwvShHRwxvk9Zj44czgWB1k5MNjLGGhX+0VBuLLQ==', N'WPS67ZS3CIMHDEBJQFYHXPHKTBN6JQI3', N'9c69699f-c4a3-405d-9508-a91e3c79cbfd', N'32423423', 0, 0, NULL, 1, 0, N'Bob', N'124 ABC', N'Nam', NULL, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [HoTen], [DiaChi], [GioiTinh], [CMND], [isDelete]) VALUES (N'e3c3c93a-de9b-49d2-ab03-3ffbe7a6d78f', N'alice@gmail.com', N'ALICE@GMAIL.COM', N'alice@gmail.com', N'ALICE@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAECXTiuZPcNBdpg1rdZsn9dwUnSM2A4mVZ4ddDDYZO3P+waPPQraK9911i0wMVJGpKg==', N'P6VVA2XDS5DLVS6V75H62YIZC3NGA3VK', N'1b263afd-7391-4fa3-bbff-6ddfa369e19e', N'01234567', 0, 0, NULL, 1, 0, N'Alice', N'123 ABC', N'Nữ', N'123456789', 0)
SET IDENTITY_INSERT [dbo].[ChiTietHDs] ON 

INSERT [dbo].[ChiTietHDs] ([Id], [LinhKienId], [HoaDonId], [SoLuongBan], [DonGia]) VALUES (1, 100, 1, CAST(1 AS Decimal(10, 0)), CAST(3600000 AS Decimal(12, 0)))
SET IDENTITY_INSERT [dbo].[ChiTietHDs] OFF
SET IDENTITY_INSERT [dbo].[DonGias] ON 

INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (5, CAST(N'2020-11-24T00:00:00.0000000' AS DateTime2), CAST(100000 AS Decimal(12, 0)), 10, 1, 1)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (6, CAST(N'2020-11-24T00:00:00.0000000' AS DateTime2), CAST(10000 AS Decimal(12, 0)), 12, 0, 1)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (7, CAST(N'2020-11-24T00:00:00.0000000' AS DateTime2), CAST(100000 AS Decimal(12, 0)), 12, 1, 2)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (8, CAST(N'2020-11-29T00:00:00.0000000' AS DateTime2), CAST(5000000 AS Decimal(12, 0)), 1000000, 1, 3)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (9, CAST(N'2020-11-29T00:00:00.0000000' AS DateTime2), CAST(5000000 AS Decimal(12, 0)), 50, 1, 4)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (10, CAST(N'2020-11-29T00:00:00.0000000' AS DateTime2), CAST(200000 AS Decimal(12, 0)), 10, 1, 5)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (11, CAST(N'2020-11-29T00:00:00.0000000' AS DateTime2), CAST(250000 AS Decimal(12, 0)), 5, 1, 7)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (12, CAST(N'2020-11-29T00:00:00.0000000' AS DateTime2), CAST(300000 AS Decimal(12, 0)), 5, 1, 8)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (13, CAST(N'2020-11-29T00:00:00.0000000' AS DateTime2), CAST(400000 AS Decimal(12, 0)), 10, 1, 9)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (14, CAST(N'2020-11-29T00:00:00.0000000' AS DateTime2), CAST(600000 AS Decimal(12, 0)), 10, 1, 10)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (15, CAST(N'2020-11-29T00:00:00.0000000' AS DateTime2), CAST(550000 AS Decimal(12, 0)), 5, 1, 11)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (16, CAST(N'2020-11-29T00:00:00.0000000' AS DateTime2), CAST(250000 AS Decimal(12, 0)), 10, 1, 12)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (17, CAST(N'2020-11-29T00:00:00.0000000' AS DateTime2), CAST(320000 AS Decimal(12, 0)), 20, 1, 13)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (18, CAST(N'2020-11-29T00:00:00.0000000' AS DateTime2), CAST(400000 AS Decimal(12, 0)), 15, 1, 14)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (19, CAST(N'2020-11-29T00:00:00.0000000' AS DateTime2), CAST(420000 AS Decimal(12, 0)), 10, 1, 15)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (20, CAST(N'2020-11-29T00:00:00.0000000' AS DateTime2), CAST(490000 AS Decimal(12, 0)), 45, 1, 16)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (21, CAST(N'2020-11-29T00:00:00.0000000' AS DateTime2), CAST(490000 AS Decimal(12, 0)), 30, 1, 17)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (22, CAST(N'2020-11-29T00:00:00.0000000' AS DateTime2), CAST(550000 AS Decimal(12, 0)), 20, 1, 18)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (23, CAST(N'2020-11-29T00:00:00.0000000' AS DateTime2), CAST(600000 AS Decimal(12, 0)), 20, 1, 19)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (24, CAST(N'2020-11-29T00:00:00.0000000' AS DateTime2), CAST(650000 AS Decimal(12, 0)), 15, 1, 20)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (25, CAST(N'2020-11-29T00:00:00.0000000' AS DateTime2), CAST(700000 AS Decimal(12, 0)), 20, 1, 21)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (26, CAST(N'2020-11-29T00:00:00.0000000' AS DateTime2), CAST(800000 AS Decimal(12, 0)), 30, 1, 22)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (27, CAST(N'2020-11-29T00:00:00.0000000' AS DateTime2), CAST(690000 AS Decimal(12, 0)), 50, 1, 23)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (28, CAST(N'2020-11-29T00:00:00.0000000' AS DateTime2), CAST(1050000 AS Decimal(12, 0)), 30, 1, 24)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (29, CAST(N'2020-11-29T00:00:00.0000000' AS DateTime2), CAST(1090000 AS Decimal(12, 0)), 25, 1, 25)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (30, CAST(N'2020-11-29T00:00:00.0000000' AS DateTime2), CAST(940000 AS Decimal(12, 0)), 20, 1, 26)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (31, CAST(N'2020-11-29T00:00:00.0000000' AS DateTime2), CAST(1290000 AS Decimal(12, 0)), 20, 1, 27)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (32, CAST(N'2020-11-29T00:00:00.0000000' AS DateTime2), CAST(1350000 AS Decimal(12, 0)), 20, 1, 28)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (33, CAST(N'2020-11-29T00:00:00.0000000' AS DateTime2), CAST(1390000 AS Decimal(12, 0)), 30, 1, 29)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (34, CAST(N'2020-11-29T00:00:00.0000000' AS DateTime2), CAST(1700000 AS Decimal(12, 0)), 30, 1, 30)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (35, CAST(N'2020-11-29T00:00:00.0000000' AS DateTime2), CAST(1350000 AS Decimal(12, 0)), 10, 1, 31)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (36, CAST(N'2020-11-29T00:00:00.0000000' AS DateTime2), CAST(1600000 AS Decimal(12, 0)), 30, 1, 32)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (37, CAST(N'2020-11-29T00:00:00.0000000' AS DateTime2), CAST(1270000 AS Decimal(12, 0)), 12, 1, 34)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (38, CAST(N'2020-11-29T00:00:00.0000000' AS DateTime2), CAST(1800000 AS Decimal(12, 0)), 30, 1, 35)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (39, CAST(N'2020-11-29T00:00:00.0000000' AS DateTime2), CAST(1210000 AS Decimal(12, 0)), 20, 1, 36)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (40, CAST(N'2020-11-29T00:00:00.0000000' AS DateTime2), CAST(1400000 AS Decimal(12, 0)), 20, 1, 37)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (41, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(345000 AS Decimal(12, 0)), 20, 1, 38)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (42, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(700000 AS Decimal(12, 0)), 10, 1, 39)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (43, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(850000 AS Decimal(12, 0)), 20, 1, 40)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (44, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(750000 AS Decimal(12, 0)), 20, 1, 41)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (45, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(1290000 AS Decimal(12, 0)), 0, 1, 42)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (46, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(1630000 AS Decimal(12, 0)), 10, 1, 43)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (47, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(2000000 AS Decimal(12, 0)), 20, 1, 44)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (48, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(600000 AS Decimal(12, 0)), 15, 1, 45)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (49, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(700000 AS Decimal(12, 0)), 20, 1, 46)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (50, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(900000 AS Decimal(12, 0)), 10, 1, 47)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (51, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(1100000 AS Decimal(12, 0)), 20, 1, 48)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (52, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(1100000 AS Decimal(12, 0)), 15, 1, 49)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (53, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(890000 AS Decimal(12, 0)), 50, 1, 50)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (54, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(1400000 AS Decimal(12, 0)), 20, 1, 51)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (55, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(1400000 AS Decimal(12, 0)), 20, 1, 52)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (56, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(1600000 AS Decimal(12, 0)), 30, 1, 53)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (57, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(1500000 AS Decimal(12, 0)), 20, 1, 54)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (58, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(2000000 AS Decimal(12, 0)), 30, 1, 55)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (59, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(1750000 AS Decimal(12, 0)), 10, 1, 56)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (60, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(2000000 AS Decimal(12, 0)), 10, 1, 57)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (61, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(2300000 AS Decimal(12, 0)), 20, 1, 58)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (62, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(1950000 AS Decimal(12, 0)), 20, 1, 59)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (63, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(1400000 AS Decimal(12, 0)), 10, 1, 60)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (64, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(1600000 AS Decimal(12, 0)), 15, 1, 61)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (65, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(1700000 AS Decimal(12, 0)), 30, 1, 62)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (66, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(1650000 AS Decimal(12, 0)), 20, 1, 63)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (67, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(2900000 AS Decimal(12, 0)), 40, 1, 64)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (68, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(2700000 AS Decimal(12, 0)), 15, 1, 65)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (69, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(3100000 AS Decimal(12, 0)), 20, 1, 66)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (70, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(2600000 AS Decimal(12, 0)), 10, 1, 67)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (71, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(3000000 AS Decimal(12, 0)), 20, 1, 68)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (72, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(4000000 AS Decimal(12, 0)), 20, 1, 69)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (73, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(5000000 AS Decimal(12, 0)), 10, 1, 70)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (74, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(8500000 AS Decimal(12, 0)), 15, 1, 71)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (75, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(9250000 AS Decimal(12, 0)), 12, 1, 73)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (76, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(1270000 AS Decimal(12, 0)), 20, 1, 74)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (77, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(2950000 AS Decimal(12, 0)), 12, 1, 75)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (78, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(610000 AS Decimal(12, 0)), 20, 1, 76)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (79, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(1450000 AS Decimal(12, 0)), 20, 1, 77)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (80, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(2200000 AS Decimal(12, 0)), 20, 1, 78)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (81, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(3000000 AS Decimal(12, 0)), 20, 1, 79)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (82, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(2450000 AS Decimal(12, 0)), 2, 1, 80)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (83, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(5000000 AS Decimal(12, 0)), 20, 1, 81)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (84, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(3650000 AS Decimal(12, 0)), 20, 1, 82)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (85, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(1750000 AS Decimal(12, 0)), 20, 1, 83)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (86, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(3600000 AS Decimal(12, 0)), 40, 1, 84)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (87, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(2500000 AS Decimal(12, 0)), 20, 1, 85)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (88, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(1270000 AS Decimal(12, 0)), 12, 1, 86)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (89, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(2950000 AS Decimal(12, 0)), 29, 1, 87)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (90, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(3000000 AS Decimal(12, 0)), 20, 1, 88)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (91, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(4000000 AS Decimal(12, 0)), 25, 1, 89)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (92, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(2500000 AS Decimal(12, 0)), 20, 1, 90)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (93, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(2400000 AS Decimal(12, 0)), 5, 1, 91)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (94, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(3200000 AS Decimal(12, 0)), 20, 1, 92)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (95, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(3600000 AS Decimal(12, 0)), 10, 1, 93)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (96, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(2400000 AS Decimal(12, 0)), 20, 1, 94)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (97, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(2950000 AS Decimal(12, 0)), 20, 1, 95)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (98, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(1500000 AS Decimal(12, 0)), 20, 1, 96)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (99, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(2100000 AS Decimal(12, 0)), 20, 1, 97)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (100, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(2950000 AS Decimal(12, 0)), 20, 1, 98)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (101, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(2600000 AS Decimal(12, 0)), 20, 1, 99)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (102, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(4500000 AS Decimal(12, 0)), 20, 1, 100)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (103, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(3200000 AS Decimal(12, 0)), 20, 1, 101)
GO
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (104, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(4000000 AS Decimal(12, 0)), 15, 1, 102)
INSERT [dbo].[DonGias] ([Id], [Ngay], [DonGiaBan], [GiamGia], [ApDung], [LinhKienId]) VALUES (105, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(5500000 AS Decimal(12, 0)), 20, 1, 103)
SET IDENTITY_INSERT [dbo].[DonGias] OFF
SET IDENTITY_INSERT [dbo].[HoaDons] ON 

INSERT [dbo].[HoaDons] ([Id], [MaHD], [NgayLapHD], [NgayGiao], [TiGia], [UserId], [PhuongThucThanhToan], [TinhTrang]) VALUES (1, N'HD00000000001', CAST(N'2020-12-13T18:09:29.0629418' AS DateTime2), CAST(N'2020-12-13T18:09:38.3161033' AS DateTime2), CAST(3600000 AS Decimal(18, 0)), N'e3c3c93a-de9b-49d2-ab03-3ffbe7a6d78f', N'cod', N'Đã giao hàng')
SET IDENTITY_INSERT [dbo].[HoaDons] OFF
SET IDENTITY_INSERT [dbo].[LinhKiens] ON 

INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (1, N'00001', N'SP1', N'<p>123456</p>

<p><img alt="" src="/images/products/products_description/fac5b994-8857-438e-ab5f-28449fe14fe7.jpg" style="height:100%; width:100%" /></p>
', 13, CAST(N'2020-11-27T12:20:02.4822637' AS DateTime2), N'0000166109.jpg,0000146524.png', 2, 1, 2, 100, 1)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (2, N'00002', N'SP2', N'<p>123456</p>
', 12, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'0000239535.jpg', 1, 2, 1, 2, 1)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (3, N'Hihi', N'Haha', N'<p>No</p>
', 24, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'Hihi60734.jpg', 2, 2, 12, 0, 1)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (4, N'Hihi', N'Haha', N'<p>No</p>
', 24, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'Hihi61798.jpg', 2, 1, 12, 0, 1)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (5, N'Hihihihi', N'Huhu', N'<p>Hi</p>
', 12, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'Hihihihi16825.png,Hihihihi98491.jpg,Hihihihi47073.png', 3, 3, 12, 0, 1)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (7, N'SP0001', N'Razer Goliathus', N'<h1>Razer Goliathus Mobile Stealth Edition</h1>

<p>&nbsp;</p>
', 12, CAST(N'2020-12-02T09:11:24.2300477' AS DateTime2), N'SP000183194.png,SP000135226.png', 1, 1, 0, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (8, N'SP0002', N'Razer Goliathus Small', N'<p>Razer Goliathus Small Speed Cosmic Edition</p>
', 12, CAST(N'2020-12-02T09:11:31.8791993' AS DateTime2), N'SP000266607.png,SP000247923.png,SP000220486.png', 1, 1, 50, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (9, N'SP0003', N'Razer Goliathus Small Control', N'<h1>Razer Goliathus Small Control Fissure Edition</h1>
', 12, CAST(N'2020-12-02T09:14:18.3329689' AS DateTime2), N'SP000394463.jpg,SP000314752.jpg,SP000360261.png', 1, 1, 50, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (10, N'SP0004', N'Razer Sphex V2', N'<h1>Razer Sphex V2</h1>
', 24, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP00047365.png,SP000472921.png,SP000413434.png,SP000456725.png', 1, 1, 20, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (11, N'SP0005', N'Logitech G440 Hard Gaming', N'<h1>Logitech G440 Hard Gaming</h1>
', 12, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP000515157.png,SP000581802.png', 1, 5, 12, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (12, N'SP0006', N'Fuhlen F200', N'<h1>Fuhlen F200</h1>
', 24, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP000656291.png,SP000682105.png,SP000692197.png,SP000668329.png,SP000634260.png', 3, 3, 50, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (13, N'SP0007', N'Fuhlen G3', N'<h1>Fuhlen G3</h1>
', 12, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP000720210.png,SP000794408.png,SP000758936.png', 3, 3, 70, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (14, N'SP0008', N'Fuhlen G90 Black', N'<h1>Fuhlen G90 Black</h1>
', 12, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP000862269.jpg,SP000870375.jpg', 3, 3, 40, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (15, N'SP0009', N'Fuhlen G90s RGB', N'<h1>Fuhlen G90s RGB</h1>
', 12, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP000986501.png,SP000913151.png,SP000917679.png', 3, 3, 30, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (16, N'SP0010', N'Logitech G102 RGB White', N'<h1>Logitech G102 Lightsync RGB White</h1>
', 12, CAST(N'2020-12-02T09:12:04.9434427' AS DateTime2), N'SP001078676.png,SP001069936.png,SP001045086.png', 3, 5, 150, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (17, N'SP0011', N'Logitech G102 RGB Black', N'<h1>Logitech G102 Lightsync RGB Black</h1>
', 12, CAST(N'2020-12-02T09:12:12.6073637' AS DateTime2), N'SP001136615.png,SP001116165.png', 3, 5, 200, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (18, N'SP0012', N'Fuhlen G90 Pro', N'<h1>Fuhlen G90 Pro</h1>
', 12, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP001219662.png,SP001236002.png,SP001252791.png', 3, 3, 40, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (19, N'SP0013', N'Logitech G302 Prime', N'<p>Logitech G302 Daedalus Prime</p>
', 12, CAST(N'2020-12-02T09:12:26.2017509' AS DateTime2), N'SP001315123.png,SP001363992.png,SP001342127.png,SP001350108.png,SP001354445.png', 3, 5, 20, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (20, N'SP0014', N'DareU EM901 Pink', N'<h1>DareU EM901 RGB Wireless Pink</h1>
', 12, CAST(N'2020-12-02T09:12:36.2203051' AS DateTime2), N'SP001318413.png,SP001369954.png,SP00136959.png', 3, 2, 50, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (21, N'SP0015', N'DareU EM901 Black', N'<h1>DareU EM901 RGB Wireless Black</h1>
', 12, CAST(N'2020-12-02T09:12:46.9107641' AS DateTime2), N'SP00156370.png,SP001512285.png,SP00153926.png,SP001575489.png', 3, 2, 20, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (22, N'SP0016', N'Logitech G402 Hyperion', N'<h1>Logitech G402 Hyperion</h1>
', 12, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP001612751.png,SP001636081.png,SP00168578.png,SP001687719.png,SP001692400.png', 3, 5, 75, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (23, N'SP0017', N'HyperX PulseFire Core', N'<h1>HyperX PulseFire FPS Core</h1>
', 12, CAST(N'2020-12-02T09:13:34.5462882' AS DateTime2), N'SP001741948.png,SP001741604.png,SP001768820.png,SP00177790.png', 3, 6, 60, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (24, N'SP0018', N'Razer Deathadder', N'<h1>Razer Deathadder Essential</h1>
', 12, CAST(N'2020-12-02T09:13:56.5315169' AS DateTime2), N'SP001888370.jpg,SP001821528.jpg,SP001868691.jpg,SP001880662.jpg', 3, 1, 120, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (25, N'SP0019', N'Logitech G304 Wireless', N'<h1>Logitech G304 Lightspeed Wireless</h1>
', 12, CAST(N'2020-12-02T09:12:59.1805228' AS DateTime2), N'SP00196983.jpg,SP001980438.jpg,SP001924541.jpg,SP001912102.jpg,SP001978368.jpg,SP001948168.jpg', 3, 5, 127, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (26, N'SP0020', N'Steelseries Rival 3', N'<h1>Steelseries Rival 3</h1>
', 12, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP002074862.jpg,SP002084048.jpg,SP00206974.jpg,SP002053845.jpg', 3, 4, 295, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (27, N'SP0021', N'Razer Viper Mini', N'<h1>Razer Viper Mini</h1>
', 12, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP002174825.jpg,SP002190859.jpg,SP002154522.jpg,SP002118092.jpg,SP002190171.jpg,SP002110595.jpg', 3, 1, 121, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (28, N'SP0022', N'HyperX FPS Pro', N'<h1>HyperX Pulsefire FPS Pro</h1>
', 12, CAST(N'2020-12-02T09:14:11.5231044' AS DateTime2), N'SP002263415.png,SP002224603.png,SP002273287.png,SP00229232.png', 3, 6, 127, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (29, N'SP0023', N'Razer Basilisk Essential', N'<h1>Razer Basilisk Essential</h1>
', 12, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP002361466.jpg,SP002353262.jpg,SP002396940.jpg,SP002315730.jpg', 3, 1, 295, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (30, N'SP0024', N'Logitech G403 HERO', N'<h1>Logitech G403 HERO</h1>
', 12, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP002411689.jpg,SP002499497.jpg,SP002429699.jpg,SP002458174.jpg,SP00241790.jpg,SP002456521.jpg', 3, 5, 121, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (31, N'SP0025', N'Steelseries Sensei 310', N'<p>Steelseries Sensei 310</p>
', 12, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP002563403.jpg,SP002554405.jpg,SP002520143.jpg,SP002533039.jpg', 3, 4, 12, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (32, N'SP0026', N'Razer X HyperSpeed', N'<h1>Razer Basilisk X HyperSpeed</h1>
', 12, CAST(N'2020-12-02T09:13:11.7912840' AS DateTime2), N'SP002657542.jpg,SP002615049.jpg,SP002679009.jpg,SP002686347.jpg,SP002687478.jpg,SP002622429.jpg', 3, 1, 127, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (34, N'SP0027', N'HyperX Raid RGB', N'<h1>HyperX Pulsefire Raid RGB</h1>
', 12, CAST(N'2020-12-02T09:13:43.7493940' AS DateTime2), N'SP002760436.jpg,SP002765815.jpg,SP002742390.jpg,SP002731984.jpg,SP002769784.jpg', 3, 6, 127, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (35, N'SP0028', N'Logitech G502 Hero', N'<h1>Logitech G502 Hero</h1>
', 12, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP002898680.jpg,SP002819830.jpg,SP002824446.jpg,SP00288921.jpg,SP002841599.jpg', 3, 5, 17, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (36, N'SP0029', N'HyperX Pulsefire RGB', N'<p>HyperX Pulsefire RGB</p>
', 12, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP002962081.jpg,SP002975180.jpg,SP002972205.jpg,SP002931436.jpg', 3, 6, 50, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (37, N'SP0030', N'Steelseries Rival 310', N'<h1>Steelseries Rival 310</h1>
', 12, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP003015001.jpg,SP00306720.jpg,SP003024467.jpg,SP003095142.jpg,SP003080598.jpg', 3, 4, 295, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (38, N'SP0031', N'Steelseries QcK Edge', N'<h1>Steelseries QcK Edge</h1>
', 12, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP003140526.jpg,SP003122875.jpg,SP003121494.jpg,SP003190755.jpg', 1, 4, 127, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (39, N'SP0032', N'Razer Goliathus Large', N'<h1>Razer Goliathus Large</h1>
', 12, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP003251884.jpg,SP003217891.jpg,SP003234604.jpg', 1, 1, 121, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (40, N'SP0033', N'Steelseries QCK Edge', N'<h1>Steelseries QCK Edge</h1>
', 12, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP003343290.jpg,SP003313051.jpg,SP003373698.jpg,SP00336915.jpg,SP003370624.jpg', 1, 4, 295, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (41, N'SP0034', N'Steelseries QCK Prism', N'<h1>Steelseries QCK Prism</h1>
', 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP003497737.jpg,SP003486440.jpg,SP003450190.jpg', 1, 4, 0, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (42, N'SP0035', N'Razer Firefly V2', N'<h1>Razer Firefly V2</h1>
', 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP003569098.jpg', 1, 1, 0, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (43, N'SP0036', N'Steelseries QCK Prism XL', N'<h1>Steelseries QCK Prism XL</h1>

<p>&nbsp;</p>
', 12, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP003695506.jpg,SP003643695.jpg,SP003692857.jpg,SP003694741.jpg', 1, 4, 127, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (44, N'SP0037', N'Razer Goliathus Extended', N'<p>Razer Goliathus Extended</p>
', 12, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP003755371.jpg,SP003761005.jpg,SP003781126.jpg', 1, 1, 1207, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (45, N'SP0038', N'DareU EH722S 7.1', N'<h1>DareU EH722S 7.1</h1>
', 12, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP003838165.jpg', 2, 2, 1201, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (46, N'SP0039', N'HyperX Cloud Earbuds', N'<h1>HyperX Cloud Earbuds</h1>
', 12, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP00397164.jpg,SP003939253.jpg,SP003941353.jpg,SP003927879.jpg', 2, 6, 2905, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (47, N'SP0040', N'HyperX Cloud Stinger', N'<h1>HyperX Cloud Stinger</h1>
', 12, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP00406325.jpg,SP004029289.jpg,SP004073267.jpg,SP004080718.jpg', 2, 6, 1229, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (48, N'SP0041', N'DareU EH925S Pink', N'<h1>DareU EH925S Pink</h1>
', 12, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP00418410.jpg,SP004159772.jpg', 2, 2, 7, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (49, N'SP0042', N'DareU EH925S 7.1', N'<h1>DareU EH925S 7.1</h1>
', 12, CAST(N'2020-12-02T10:06:57.9425937' AS DateTime2), N'SP004130252.jpg,SP004142096.jpg', 2, 2, 121, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (50, N'SP0043', N'DAREU EH722s MAGIC', N'<h1>DAREU EH722s MAGIC</h1>
', 12, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP004393771.jpg,SP004379893.jpg,SP004320777.jpg', 2, 2, 7, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (51, N'SP0044', N'Razer Kraken X - Black', N'<h1>Razer Kraken X - Black</h1>
', 24, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP004410570.jpg,SP004416002.jpg,SP004460977.jpg,SP004444631.jpg,SP004495467.jpg', 2, 1, 2905, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (52, N'SP0045', N'Razer Kraken X - Blue', N'<h1>Razer Kraken X - Blue</h1>
', 24, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP004564116.jpg,SP004546771.jpg,SP004582375.jpg,SP004521295.jpg,SP004510560.jpg', 2, 1, 2905, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (53, N'SP0046', N'Logitech G331', N'<h1>Logitech G331</h1>
', 24, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP004672769.jpg,SP004697968.jpg,SP004694242.jpg,SP004625825.jpg', 2, 5, 1207, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (54, N'SP0047', N'HyperX Cloud Stinger', N'<h1>HyperX Cloud Stinger</h1>
', 24, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP004725891.jpg,SP004714189.jpg,SP004768508.jpg,SP004758554.jpg,SP004765231.jpg', 2, 6, 127, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (55, N'SP0048', N'Logitech G431', N'<h1>Logitech G431</h1>
', 24, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP004853500.jpg,SP004824123.jpg,SP004844978.jpg', 2, 5, 12, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (56, N'SP0049', N'Razer BlackShark V2', N'<h1>Razer BlackShark V2</h1>
', 24, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP004984476.jpg', 2, 1, 29, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (57, N'SP0050', N'Kingston HyperX Cloud', N'<h1>Kingston HyperX Cloud</h1>
', 24, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP005064766.jpg,SP005018232.jpg,SP005054409.jpg,SP00502813.jpg', 2, 6, 5, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (58, N'SP0051', N'SteelSeries Arctis 3', N'<h1>SteelSeries Arctis 3</h1>
', 24, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP005197351.jpg,SP005186017.jpg,SP005126034.jpg,SP005141164.jpg', 2, 4, 127, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (59, N'SP0052', N'Logitech G Pro Gaming', N'<h1>Logitech G Pro Gaming</h1>
', 24, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP005220031.jpg,SP005253862.jpg,SP005292857.jpg,SP00527626.jpg', 2, 5, 295, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (60, N'SP0053', N'SteelSeries Arctis 1', N'<h1>SteelSeries Arctis 1</h1>
', 24, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP00536117.jpg,SP005367186.jpg,SP005340165.jpg,SP005361705.jpg', 2, 4, 12, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (61, N'SP0054', N'Razer Kraken X USB', N'<h1>Razer Kraken X USB</h1>
', 24, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP005446306.jpg,SP005489215.jpg,SP005452818.jpg', 2, 1, 127, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (62, N'SP0055', N'Razer Hammerhead D', N'<h1>Razer Hammerhead Duo</h1>
', 24, CAST(N'2020-12-02T12:51:19.7800392' AS DateTime2), N'SP006560306.jpg,SP006552673.jpg,SP006552313.jpg,SP00653643.jpg,SP006531601.jpg', 2, 1, 295, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (63, N'SP0056', N'Razer Kraken X Mercury', N'<h1>Razer Kraken X Mercury</h1>
', 24, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP005670259.jpg,SP005645193.jpg,SP005617009.jpg,SP005687558.jpg', 2, 1, 127, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (64, N'SP0057', N'HyperX Cloud II', N'<h1>HyperX Cloud II</h1>
', 24, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP005731793.jpg,SP005712342.jpg,SP005727608.jpg,SP005779941.jpg', 2, 6, 29, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (65, N'SP0058', N'Razer Kraken Tournament', N'<h1>Razer Kraken Tournament</h1>
', 24, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP005863859.jpg,SP005810608.jpg,SP005861925.jpg,SP005815148.jpg', 2, 1, 29, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (66, N'SP0059', N'SteelSeries Arctis 5', N'<h1>SteelSeries Arctis 5</h1>
', 24, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP005956825.jpg,SP005938262.jpg,SP00591678.jpg,SP005992059.jpg', 2, 4, 127, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (67, N'SP0060', N'HyperX Cloud Flight', N'<h1>HyperX Cloud Flight</h1>
', 24, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP006033124.jpg,SP006067624.jpg,SP006012756.jpg', 2, 6, 29, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (68, N'SP0061', N'HyperX Cloud Alpha', N'<h1>HyperX Cloud Alpha</h1>
', 24, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP006174005.jpg,SP006185669.jpg,SP006179065.jpg,SP006167723.jpg', 2, 6, 29, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (69, N'SP0062', N'Razer Nari', N'<h1>Razer Nari</h1>
', 24, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP006210806.jpg,SP006296344.jpg,SP006232274.jpg,SP006277810.jpg', 2, 1, 12, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (70, N'SP0063', N'Razer Nari Ultimate', N'<h1>Razer Nari Ultimate</h1>
', 24, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP006399555.jpg,SP006355157.jpg,SP006333560.jpg,SP006318411.jpg', 2, 1, 127, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (71, N'SP0064', N'HyperX Cloud Orbit', N'<p>HyperX Cloud Orbit</p>
', 24, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP006421861.jpg,SP006441948.jpg,SP006474570.jpg,SP00642872.jpg,SP006461976.jpg', 2, 6, 295, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (73, N'SP0065', N'SteelSeries Arctis Pro', N'<h1>SteelSeries Arctis Pro</h1>
', 36, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP006598370.jpg,SP006551457.jpg,SP006570341.jpg,SP006565440.jpg,SP00653743.jpg,SP006542774.jpg', 2, 4, 1229, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (74, N'SP0066', N'Logitech G560', N'<p>Logitech G560</p>
', 24, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP006644749.jpg,SP00669672.jpg', 5, 5, 127, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (75, N'SP0067', N'Razer Nommo Chroma', N'<p>Razer Nommo Chroma</p>
', 24, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP006738592.jpg,SP006765047.jpg,SP00672035.jpg', 5, 1, 295, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (76, N'SP0068', N'Logitech Z213 2.1', N'<h1>Logitech Z213 2.1</h1>
', 24, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP006831852.jpg,SP006885023.jpg,SP006879213.jpg,SP006821418.jpg,SP006889812.jpg', 5, 5, 295, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (77, N'SP0069', N'Logitech Z333', N'<h1>Logitech Z333</h1>
', 24, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP006955219.jpg,SP006957808.jpg,SP006959073.jpg,SP006919577.jpg', 5, 5, 127, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (78, N'SP0070', N'Logitech Z337 (BLUETOOTH)', N'<p>Logitech Z337 (BLUETOOTH)</p>
', 24, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP007036962.jpg,SP007067793.jpg,SP007016917.jpg', 5, 5, 121, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (79, N'SP0071', N'Logitech Z607 5.1', N'<h1>Logitech Z607 5.1</h1>
', 24, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP007124918.jpg', 5, 5, 295, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (80, N'SP0072', N'Razer Nommo', N'<h1>Razer Nommo</h1>
', 24, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP00722778.jpg,SP007258892.jpg,SP007275012.jpg,SP007255984.jpg,SP007253511.jpg', 5, 1, 127, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (81, N'SP0073', N'Razer Leviathan 5.1 ', N'<h1>Razer Leviathan 5.1&nbsp;</h1>
', 36, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP007329942.jpg,SP007392686.jpg,SP00739588.jpg,SP007329663.jpg,SP007344876.jpg', 5, 1, 295, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (82, N'SP0074', N' Razer Ducky One 2', N'<p>&nbsp;Razer Ducky One 2</p>
', 24, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP007462965.jpg,SP007468940.jpg,SP007465924.jpg', 4, 1, 29, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (83, N'SP0075', N'DAREU EK87 - Black', N'<p>DAREU EK87 - Black</p>
', 24, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP007528244.jpg,SP007566905.jpg,SP007567018.jpg', 4, 2, 29, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (84, N'SP0076', N'Steelseries Apex 7', N'<p>Steelseries Apex 7</p>
', 24, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP007691958.jpg,SP007615420.jpg,SP007614858.jpg', 4, 4, 29, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (85, N'SP0077', N'Steelseries Apex 5', N'<p>Steelseries Apex 5</p>
', 24, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP007793129.jpg,SP007736061.jpg,SP007717368.jpg', 4, 4, 29, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (86, N'SP0078', N'Steelseries Apex 3', N'<p>Steelseries Apex 3</p>
', 24, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP007827388.jpg,SP007864288.jpg,SP007881157.jpg', 4, 4, 12, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (87, N'SP0079', N'Razer Tartarus Pro', N'<p>Razer Tartarus Pro</p>
', 24, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP007911889.jpg,SP007996459.jpg,SP007920825.jpg', 4, 1, 295, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (88, N'SP0080', N'Razer Ornata Chroma', N'<p>Razer Ornata Chroma</p>
', 24, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP008034065.jpg,SP008014935.jpg,SP008051397.jpg', 4, 1, 29, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (89, N'SP0081', N'Razer Blackwidow Green', N'<p>Razer Blackwidow Green</p>
', 24, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP008167091.jpg,SP008168861.jpg,SP008184547.jpg', 4, 1, 295, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (90, N'SP0082', N'Logitech G913', N'<p>Logitech G913</p>
', 24, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP008221764.jpg,SP008225128.jpg,SP008281564.jpg', 4, 5, 127, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (91, N'SP0083', N'Logitech G813 RGB', N'<p>Logitech G813 RGB</p>
', 24, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP00839465.jpg,SP008374459.jpg,SP008330696.jpg', 4, 5, 121, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (92, N'SP0084', N'Logitech G610 Orion', N'<p>Logitech G610 Orion</p>
', 24, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP008448676.jpg,SP008474913.jpg', 4, 5, 127, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (93, N'SP0095', N'Logitech G213', N'<p>Logitech G213</p>
', 24, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP009535068.jpg,SP009515644.jpg,SP009569812.jpg', 4, 5, 127, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (94, N'SP0086', N'Logitech G Pro X', N'<p>Logitech G Pro X</p>
', 24, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP00864271.jpg,SP008653532.jpg,SP008630296.jpg', 4, 5, 127, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (95, N'SP0087', N'HyperX Alloy Elite', N'<p>HyperX Alloy Elite</p>
', 24, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP00876114.jpg', 4, 6, 295, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (96, N'SP0088', N'HyperX Alloy Core', N'<p>HyperX Alloy Core</p>
', 24, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP008865299.jpg,SP008848112.jpg,SP008852490.jpg', 4, 6, 29, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (97, N'SP0089', N'DareU EK1280 RGB', N'<p>DareU EK1280 RGB</p>
', 24, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP008999849.jpg,SP00899908.jpg,SP008935372.jpg', 4, 2, 127, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (98, N'SP0090', N'Fuhlen M87S RGB', N'<p>Fuhlen M87S RGB</p>
', 24, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP009039261.jpg,SP00905921.jpg', 4, 3, 127, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (99, N'SP0091', N'Fuhlen G900L', N'<p>Fuhlen G900L</p>
', 24, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP009149438.jpg,SP009145342.jpg,SP009132615.jpg', 4, 3, 295, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (100, N'SP0092', N'Fuhlen Eraser Mechanical', N'<p>Fuhlen Eraser Mechanical</p>
', 24, CAST(N'2020-12-02T21:46:48.0080508' AS DateTime2), N'SP009237207.jpg,SP009215062.jpg', 4, 3, 294, 1, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (101, N'SP0093', N'Fuhlen D (Destroyer)', N'<p>Fuhlen D (Destroyer)</p>
', 24, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP0093344.jpg,SP009383484.jpg,SP009370566.jpg', 4, 3, 295, 0, 0)
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (102, N'SP0094', N'DareU EK87 Pink', N'<p>DareU EK87 Pink</p>
', 24, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP00943801.jpg,SP009454109.jpg', 4, 2, 127, 0, 0)
GO
INSERT [dbo].[LinhKiens] ([Id], [MaLK], [TenLK], [MoTa], [TGBH], [NgayCapNhat], [Hinh], [LoaiId], [NCCId], [SLTonKho], [DaBan], [isDelete]) VALUES (103, N'SP0095', N'HyperX Alloy', N'<p>HyperX Alloy</p>
', 24, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SP00958503.jpg,SP009521609.jpg,SP009511054.jpg', 4, 6, 1229, 0, 0)
SET IDENTITY_INSERT [dbo].[LinhKiens] OFF
SET IDENTITY_INSERT [dbo].[LoaiLinhKiens] ON 

INSERT [dbo].[LoaiLinhKiens] ([Id], [MaLoai], [Ten], [isDelete]) VALUES (1, N'00004', N'Lót chuột', 0)
INSERT [dbo].[LoaiLinhKiens] ([Id], [MaLoai], [Ten], [isDelete]) VALUES (2, N'00003', N'Tai nghe', 0)
INSERT [dbo].[LoaiLinhKiens] ([Id], [MaLoai], [Ten], [isDelete]) VALUES (3, N'00002', N'Chuột', 0)
INSERT [dbo].[LoaiLinhKiens] ([Id], [MaLoai], [Ten], [isDelete]) VALUES (4, N'00001', N'Bàn phím', 0)
INSERT [dbo].[LoaiLinhKiens] ([Id], [MaLoai], [Ten], [isDelete]) VALUES (5, N'00005', N'Loa', 0)
INSERT [dbo].[LoaiLinhKiens] ([Id], [MaLoai], [Ten], [isDelete]) VALUES (6, N'00005', N'Loa', 1)
SET IDENTITY_INSERT [dbo].[LoaiLinhKiens] OFF
SET IDENTITY_INSERT [dbo].[NhaCungCaps] ON 

INSERT [dbo].[NhaCungCaps] ([Id], [MaNCC], [TenNCC], [MoTa], [isDelete]) VALUES (1, N'00001', N'Razer', NULL, 0)
INSERT [dbo].[NhaCungCaps] ([Id], [MaNCC], [TenNCC], [MoTa], [isDelete]) VALUES (2, N'00002', N'DareU', NULL, 0)
INSERT [dbo].[NhaCungCaps] ([Id], [MaNCC], [TenNCC], [MoTa], [isDelete]) VALUES (3, N'00003', N'Fuhlen', NULL, 0)
INSERT [dbo].[NhaCungCaps] ([Id], [MaNCC], [TenNCC], [MoTa], [isDelete]) VALUES (4, N'00004', N'SteelSeries', NULL, 0)
INSERT [dbo].[NhaCungCaps] ([Id], [MaNCC], [TenNCC], [MoTa], [isDelete]) VALUES (5, N'00005', N'Logitech', NULL, 0)
INSERT [dbo].[NhaCungCaps] ([Id], [MaNCC], [TenNCC], [MoTa], [isDelete]) VALUES (6, N'00006', N'HyperX', NULL, 0)
SET IDENTITY_INSERT [dbo].[NhaCungCaps] OFF
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
ALTER TABLE [dbo].[ChiTietHDs]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHDs_HoaDons_HoaDonId] FOREIGN KEY([HoaDonId])
REFERENCES [dbo].[HoaDons] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ChiTietHDs] CHECK CONSTRAINT [FK_ChiTietHDs_HoaDons_HoaDonId]
GO
ALTER TABLE [dbo].[ChiTietHDs]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHDs_LinhKiens_LinhKienId] FOREIGN KEY([LinhKienId])
REFERENCES [dbo].[LinhKiens] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ChiTietHDs] CHECK CONSTRAINT [FK_ChiTietHDs_LinhKiens_LinhKienId]
GO
ALTER TABLE [dbo].[CTGiaos]  WITH CHECK ADD  CONSTRAINT [FK_CTGiaos_HoaDonNhapHangs_HDNhapId] FOREIGN KEY([HDNhapId])
REFERENCES [dbo].[HoaDonNhapHangs] ([Id])
GO
ALTER TABLE [dbo].[CTGiaos] CHECK CONSTRAINT [FK_CTGiaos_HoaDonNhapHangs_HDNhapId]
GO
ALTER TABLE [dbo].[CTGiaos]  WITH CHECK ADD  CONSTRAINT [FK_CTGiaos_LinhKiens_LinhKienId] FOREIGN KEY([LinhKienId])
REFERENCES [dbo].[LinhKiens] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CTGiaos] CHECK CONSTRAINT [FK_CTGiaos_LinhKiens_LinhKienId]
GO
ALTER TABLE [dbo].[DonGias]  WITH CHECK ADD  CONSTRAINT [FK_DonGias_LinhKiens_LinhKienId] FOREIGN KEY([LinhKienId])
REFERENCES [dbo].[LinhKiens] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DonGias] CHECK CONSTRAINT [FK_DonGias_LinhKiens_LinhKienId]
GO
ALTER TABLE [dbo].[GioHangs]  WITH CHECK ADD  CONSTRAINT [FK_GioHangs_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GioHangs] CHECK CONSTRAINT [FK_GioHangs_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[GioHangs]  WITH CHECK ADD  CONSTRAINT [FK_GioHangs_LinhKiens_LinhKienId] FOREIGN KEY([LinhKienId])
REFERENCES [dbo].[LinhKiens] ([Id])
GO
ALTER TABLE [dbo].[GioHangs] CHECK CONSTRAINT [FK_GioHangs_LinhKiens_LinhKienId]
GO
ALTER TABLE [dbo].[HoaDonNhapHangs]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonNhapHangs_NhaCungCaps_NCCId] FOREIGN KEY([NCCId])
REFERENCES [dbo].[NhaCungCaps] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HoaDonNhapHangs] CHECK CONSTRAINT [FK_HoaDonNhapHangs_NhaCungCaps_NCCId]
GO
ALTER TABLE [dbo].[HoaDons]  WITH CHECK ADD  CONSTRAINT [FK_HoaDons_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[HoaDons] CHECK CONSTRAINT [FK_HoaDons_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[LinhKiens]  WITH CHECK ADD  CONSTRAINT [FK_LinhKiens_LoaiLinhKiens_LoaiId] FOREIGN KEY([LoaiId])
REFERENCES [dbo].[LoaiLinhKiens] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LinhKiens] CHECK CONSTRAINT [FK_LinhKiens_LoaiLinhKiens_LoaiId]
GO
ALTER TABLE [dbo].[LinhKiens]  WITH CHECK ADD  CONSTRAINT [FK_LinhKiens_NhaCungCaps_NCCId] FOREIGN KEY([NCCId])
REFERENCES [dbo].[NhaCungCaps] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LinhKiens] CHECK CONSTRAINT [FK_LinhKiens_NhaCungCaps_NCCId]
GO
