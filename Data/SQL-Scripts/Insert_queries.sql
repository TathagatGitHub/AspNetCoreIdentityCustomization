USE [aspnet-AspCoreApplicationIdentity]
GO

INSERT INTO [dbo].[schedule]
           ([SchedId]
           ,[ScheduleName]
           ,[ClientName]
           ,[NetworkName]
           ,[Weekdate])
     VALUES
           (2
           ,'Schedule_2'
           ,'Hims'
           ,'CBS'
           ,getdate())
GO
---- then run this

USE [aspnet-AspCoreApplicationIdentity]
GO

INSERT INTO [dbo].[PostLog]
           ([PostLogId]
           ,[SchedId]
           ,[ScheduleName]
           ,[WeekNbr]
           ,[WeekDate]
           ,[CreateDt]
           ,[UpdateDt])
     VALUES
           (2
           ,2
           ,'Schedule_2'
           ,2
           ,'03-19-2020'
           ,getdate()
           ,getdate())
GO


