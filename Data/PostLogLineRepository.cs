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
                        await connection.ExecuteAsync(
                            "INSERT INTO [PostLogLine] (NetworkName , DayPartDesc,SpotLen,Rate,Imp,SpotDate,SpotTime,MediaTypeCode,ISCI,SigmaProgramName,BuyType) VALUES (@NetworkName, @DayPartDesc)",
                            postLogLines.Select(u => new { NetworkName = u.NetworkName, DayPartDesc =u.DayPartDesc,
                                SpotLen =u.SpotLen,
                                Rate=u.Rate,
                                Imp=u.Imp,
                                SpotDate=u.SpotDate,
                                SpotTime=u.SpotTime,
                                MediaTypeCode=u.MediaTypeCode,
                                ISCI=u.ISCI,
                                SigmaProgramName=u.SigmaProgramName,
                                BuyType=u.BuyType
                            })).ConfigureAwait(false);
                   }
                
                //SqlTransaction transaction = connection.BeginTransaction();
                //using (var bulkCopy = new SqlBulkCopy(this.connection, SqlBulkCopyOptions.KeepIdentity))
                //{
                //    bulkCopy.BatchSize = 3000;
                //    //bulkCopy.NotifyAfter = 1000;
                //    //bulkCopy.SqlRowsCopied += (sender, eventArgs) => logger.Info($"Wrote { eventArgs.RowsCopied } records to target table.");
                //    bulkCopy.DestinationTableName = "[" + resultTable.TableName + "]";
                //    bulkCopy.BulkCopyTimeout = 0;
                //    try
                //    {
                //        //AutoMapColumns(bulkCopy, resultTable, resultTable.TableName);
                //        //if (bulkCopy.ColumnMappings.Count < 0)
                //        //    throw new Exception($"No Column Mappings found for the API Datafeed. Please check the target table \"{ resultTable.TableName}\" existance.");

                //        bulkCopy.WriteToServer(resultTable);
                //        bulkCopy.Close();
                //    }
                //    catch (Exception ex)
                //    {
                //        //transaction.Rollback();
                //        bulkCopy.Close();
                //        connection.Close();
                //        throw ex;
                //    }
                //}
                ////transaction.Commit();
                ////https://stackoverflow.com/questions/12521692/c-sharp-bulk-insert-sqlbulkcopy-update-if-exists/12535726return true;

           // }
        }

    }
}