using GenericStoredProcedure.API.Library.ConnectionFactory.Interfaces;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;

namespace GenericStoredProcedure.API.Library.ConnectionFactory
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public ConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// There is an Generic DB Connection connection. You can change DefaultConnection from appsettings.json
        /// </summary>
        /// <returns>MySQL connection</returns>
        public IDbConnection DbConnection()
        {
            return new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
