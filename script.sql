create database QLNS
go
USE [QLNS]
GO
/****** Object:  Table [dbo].[CHUCVU]    Script Date: 03/07/20 10:22:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHUCVU](
	[Idcv] [int] IDENTITY(1,1) NOT NULL,
	[Tencv] [nvarchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Idcv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHANVIEN]    Script Date: 03/07/20 10:22:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHANVIEN](
	[Idnv] [varchar](10) NOT NULL,
	[Hoten] [nvarchar](50) NOT NULL,
	[Ns] [datetime] NOT NULL,
	[Gt] [nvarchar](5) NOT NULL,
	[Idtinh] [int] NULL,
	[Sdt] [varchar](12) NOT NULL,
	[Idpban] [int] NULL,
	[Thamnien] [int] NOT NULL,
	[Trangthai] [nvarchar](20) NULL,
	[Idcv] [int] NULL,
	[Username] [varchar](30) NOT NULL,
	[Pass] [varchar](30) NOT NULL,
	[Email] [varchar](30) NOT NULL,
	[Ngayvaolam] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Idnv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHONGBAN]    Script Date: 03/07/20 10:22:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHONGBAN](
	[Idpban] [int] IDENTITY(1,1) NOT NULL,
	[Tenpban] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Idpban] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TINHTHANH]    Script Date: 03/07/20 10:22:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TINHTHANH](
	[Idtinh] [int] IDENTITY(1,1) NOT NULL,
	[Tentinh] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Idtinh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[NHANVIEN]  WITH CHECK ADD FOREIGN KEY([Idcv])
REFERENCES [dbo].[CHUCVU] ([Idcv])
GO
ALTER TABLE [dbo].[NHANVIEN]  WITH CHECK ADD FOREIGN KEY([Idpban])
REFERENCES [dbo].[PHONGBAN] ([Idpban])
GO
ALTER TABLE [dbo].[NHANVIEN]  WITH CHECK ADD FOREIGN KEY([Idtinh])
REFERENCES [dbo].[TINHTHANH] ([Idtinh])
GO
insert into CHUCVU values (N'Trưởng phòng'), (N'Nhân viên'), (N'Phó phòng')
go
insert into PHONGBAN values (N'Kế toán & HCNS')
go
insert into TINHTHANH values (N'Hà Nội')
go
insert into NHANVIEN values ('admin', N'Xin chào', '1998-12-02', 'Nam', 1, '0326373667', 1, 0, N'Đang làm', 1, 'admin', 'admin', 'a@gmail.com', '1998-01-01')
go