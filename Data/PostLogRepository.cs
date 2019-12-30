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
    public class PostLogRepository
    {
        private readonly string connection;
        private readonly ILogger<PostLogRepository> _logger;
        public PostLogRepository(IConfiguration configuration, ILogger<PostLogRepository> logger)
        {
            connection = configuration.GetConnectionString("DefaultConnection");
            _logger = logger;
        }

        public PostLog GetPostLog (int PostLogId)
        {
            _logger.LogInformation("GetPostLog - {PostLogId}" );
            PostLog logs;
            IEnumerable<PostLog> postLogs;
            using (var connection = new SqlConnection(this.connection))
            {
                var p = new DynamicParameters();
                p.Add("@PostLogId", PostLogId);

                string sql = "select * from dbo.PostLog where PostLogId = @PostLogId";

                logs = connection.QuerySingle<PostLog>(sql, p);
                //  postLogs = connection.Query<PostLog>(sql, p);
                postLogs = connection.Query<PostLog>(sql);
                //foreach (var person in logs)
                //{
                //    Console.WriteLine($"{ person.PostLogId } { person.SchedId }");
                //}


            }

            return logs;



        }
    }
}
