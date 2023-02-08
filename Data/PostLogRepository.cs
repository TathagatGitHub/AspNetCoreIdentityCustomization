using AspNetCoreIdentityCustomization.Core;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Microsoft.Extensions.Logging;
using System.Globalization;

namespace AspNetCoreIdentityCustomization.Data
{
    public class PostLogRepository: IPosLogRepository
    {
        private readonly string connection;
        private readonly ILogger<PostLogRepository> _logger;
        private readonly IConfiguration _config;
        public PostLogRepository(IConfiguration configuration, ILogger<PostLogRepository> logger)
        {
            connection = configuration.GetConnectionString("DefaultConnection");
            _config = configuration;

            _logger = logger;
        }

        public IEnumerable<PostLog> GetPostLog (int PostLogId)
        {
            _logger.LogInformation("GetPostLog - {PostLogId}" );
            String _loglvel = _config["Logging:LogLevel:Default"];

            PostLog logs;
            IEnumerable<PostLog> postLogs;
            using (var connection = new SqlConnection(this.connection))
            {
                var p = new DynamicParameters();
                p.Add("@PostLogId", PostLogId);

                string sql = "select * from dbo.PostLog where PostLogId = @PostLogId";

                logs = connection.QuerySingle<PostLog>(sql, p);
                //  postLogs = connection.Query<PostLog>(sql, p);
                postLogs = connection.Query<PostLog>(sql,p);
                //foreach (var person in logs)
                //{
                //    Console.WriteLine($"{ person.PostLogId } { person.SchedId }");
                //}


            }
            //return logs; // only object
            return postLogs; // list of obejctst



        }

        public IEnumerable<PostLog> GetPostLogList()
        {
            _logger.LogInformation("GetPostLogList");
                  
            IEnumerable<PostLog> postLogs;
            using (var connection = new SqlConnection(this.connection))
            {
                string sql = "select PostLogId ,SchedId ,ScheduleName ,WeekNbr ,WeekDate,CreateDt,UpdateDt from dbo.PostLog";
                
                postLogs = connection.Query<PostLog>(sql);
                
            }
            //return logs; // only object
            return postLogs; // list of obejctst
        }

        public PostLog GetOnePostLog(int PostLogId)
        {
            _logger.LogInformation("GetOnePostLog");
            
            PostLog log;
            
            using (var connection = new SqlConnection(this.connection))
            {
                var p = new DynamicParameters();
                p.Add("@PostLogId", PostLogId);

                string sql = "select * from dbo.PostLog where PostLogId = @PostLogId";

                log = connection.QuerySingle<PostLog>(sql, p);
            
            }
            return log; // only object
            
        }

        public IEnumerable<string> GetScheduleList()
        {
            _logger.LogInformation("GetScheduleList");

            IEnumerable<string> scheduleList;
            using (var connection = new SqlConnection(this.connection))
            {
                string sql = "select schedid, scheduleName from dbo.[schedule]";

                scheduleList = connection.Query<string>(sql);

            }
            //return logs; // only object
            return scheduleList; // list of obejctst
        }
        public string InsertPostLog(PostLog postLog)
        {
            _logger.LogInformation("InsertPostlog");

            IEnumerable<string> scheduleList;
          // DateTime dt=new DateTime(postLog.WeekDate);
            var connection = new SqlConnection(this.connection) ;
            string stm = "INSERT INTO [PostLog] ([PostLogId],[SchedId],[ScheduleName],[WeekNbr],[WeekDate],[CreateDt],[UpdateDt])VALUES(";
            stm = stm + postLog.PostLogId + "," + postLog.SchedId + ",'" + postLog.ScheduleName + "'," + postLog.WeekNbr + ",'" + postLog.WeekDate + "','" + postLog.CreateDt + "','" + postLog.UpdateDt + "')";
            //connection.Execute("INSERT INTO Event (EventLocationId, EventName, EventDate, DateCreated) VALUES(1, 'InsertedEvent', '2019-01-01', GETUTCDATE())");
            connection.Execute(stm);

           
            return "Success"; // list of obejctst
        }

        



    }
}
