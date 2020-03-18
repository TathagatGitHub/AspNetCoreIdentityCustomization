using AspNetCoreIdentityCustomization.Core;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Microsoft.Extensions.Logging;
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
    }
}
