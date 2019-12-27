
using System;
using System.Collections.Generic;
using System.Data;
//using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;
using System.Text;

namespace AspNetCoreIdentityCustomization.Data
{
    public class ConnectionFactory
    {
        private IDbConnection _connection;
        //private readonly IOptions<DBConnectionStrings> _configs;
        public IConfiguration configuration { get; }
        public ConnectionFactory(IConfiguration Configs)
        {
            configuration = Configs;
        }

        public IDbConnection GetConnection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new SqlConnection(configuration["ConnectionStrings:DefaultConnection"]);
                    //return ConfigurationManager.ConnectionStrings[name].ConnectionString;
                }
                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }
                return _connection;
            }
        }

        public void CloseConnection()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }
    }
}