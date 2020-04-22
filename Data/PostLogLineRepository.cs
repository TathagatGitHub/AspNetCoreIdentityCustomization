using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using AspNetCoreIdentityCustomization.Core;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreIdentityCustomization.Data
{
    public class PostLogLineRepository : IPostLogLine
    {
        private readonly string connection;
        private readonly ILogger<PostLogLineRepository> _logger;
        private readonly IConfiguration _config;
        public PostLogLineRepository(IConfiguration configuration, ILogger<PostLogLineRepository> logger)
        {
            connection = configuration.GetConnectionString("DefaultConnection");
            _config = configuration;

            _logger = logger;
        }
        public async void InsertBulkPostLogLineAsync(IEnumerable<PostLogLine> postLogLines)
        {

            //using (var connection = new SqlConnection(this.connection))
            //{
            //   // connection.Open();

           

            using (var connection = new SqlConnection(this.connection))
            {
                SqlTransaction transaction = connection.BeginTransaction("BulkCopy");
                try
                        {
                       
                        await connection.ExecuteAsync(
                                "INSERT INTO [PostLogLine] (NetworkName , DayPartDesc,SpotLen,Rate,Imp,SpotDate,SpotTime,MediaTypeCode,ISCI,SigmaProgramName,BuyType) " +
                                "VALUES (@NetworkName, @DayPartDesc,@SpotLen,@Rate,@Imp,@SpotDate,@SpotTime,@MediaTypeCode,@ISCI,@SigmaProgramName,@BuyType)",
                                postLogLines.Select(u => new
                                {
                                    NetworkName = u.NetworkName,
                                    DayPartDesc = u.DayPartDesc,
                                    SpotLen = u.SpotLen,
                                    Rate = u.Rate,
                                    Imp = u.Imp,
                                    SpotDate = u.SpotDate,
                                    SpotTime = u.SpotTime,
                                    MediaTypeCode = u.MediaTypeCode,
                                    ISCI = u.ISCI,
                                    SigmaProgramName = u.SigmaProgramName,
                                    BuyType = u.BuyType
                                })).ConfigureAwait(false);
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback("BulkCopy");
                            connection.Close();
                            throw ex;
                        }

                    }

                
              
        }

    }
}