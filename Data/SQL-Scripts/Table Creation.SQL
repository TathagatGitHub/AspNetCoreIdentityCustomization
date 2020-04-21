USE [aspnet-AspCoreApplicationIdentity]
GO

/****** Object:  Table [dbo].[PostLog]    Script Date: 1/8/2020 8:46:55 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PostLog](
	[PostLogId] [int] NOT NULL,
	[SchedId] [int] NULL,
	[ScheduleName] [nchar](10) NULL,
	[WeekNbr] [int] NULL,
	[WeekDate] [date] NULL,
	[CreateDt] [date] NULL,
	[UpdateDt] [date] NULL,
 CONSTRAINT [PK_postlog_postlogID] PRIMARY KEY CLUSTERED 
(
	[PostLogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PostLog]  WITH CHECK ADD FOREIGN KEY([SchedId])
REFERENCES [dbo].[schedule] ([SchedId])
GO


USE [aspnet-AspCoreApplicationIdentity]
GO

/****** Object:  Table [dbo].[schedule]    Script Date: 1/8/2020 8:49:28 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[schedule](
	[SchedId] [int] NOT NULL,
	[ScheduleName] [nvarchar](50) NULL,
	[ClientName] [nvarchar](50) NULL,
	[NetworkName] [nvarchar](50) NULL,
	[Weekdate] [date] NULL,
 CONSTRAINT [PK_SchedId] PRIMARY KEY NONCLUSTERED 
(
	[SchedId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].PostLogLine(
	NetworkName [nvarchar](100) NOT NULL,
	DayPartDesc [nvarchar](50) NULL,
	SpotLen [int] NULL,
	Rate decimal NULL,
	Imp decimal NULL,
	SpotDate [date] NULL,
	SpotTime [nvarchar](10) NULL,
	MediaTypeCode [nvarchar](10) NULL,
	ISCI [nvarchar](15) NULL,
	SigmaProgramName [nvarchar](100) NULL,
	BuyType [nvarchar](10) NULL
) 
GO
