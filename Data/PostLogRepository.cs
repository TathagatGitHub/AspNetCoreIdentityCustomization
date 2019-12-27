using AspNetCoreIdentityCustomization.Core;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AspNetCoreIdentityCustomization.Data
{
    public class PostLogRepository
    {
        private readonly string connection;

        public PostLogRepository(IConfiguration configuration)
        {
            connection = configuration.GetConnectionString("DefaultConnection");
        }

        public PostLog GetPostLog (int PostLogId)
        {
            PostLog logs;
            using (var connection = new SqlConnection(this.connection))
            {
                var p = new DynamicParameters();
                p.Add("@PostLogId", PostLogId);

                string sql = "select * from dbo.Person where LastName = @LastName";

                logs = connection.QuerySingle<PostLog>(sql, p);
                //foreach (var person in logs)
                //{
                //    Console.WriteLine($"{ person.PostLogId } { person.SchedId }");
                //}

                
            }

            return logs;



        }
    }
}
