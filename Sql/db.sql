USE [master]
GO
/****** Object:  Database [MachineStream]    Script Date: 2022/8/8 10:22:06 ******/
CREATE DATABASE [MachineStream]
GO
CREATE TABLE [dbo].[MachineStatus](
	[MachineId] [uniqueidentifier] NOT NULL,
	[Status] [nvarchar](10) NULL,
	[CreateDate] [datetime] NULL,
	[LastUpdateDate] [datetime] NULL,
 CONSTRAINT [PK_MachineStatus_1] PRIMARY KEY CLUSTERED 
(
	[MachineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO