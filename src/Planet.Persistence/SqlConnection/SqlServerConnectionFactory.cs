using Microsoft.Extensions.Configuration;
using Planet.Application.Services.SqlConnection;
using System.Data.Common;


namespace Planet.Persistence.SqlConnection
{
    public sealed class SqlServerConnectionFactory : ISqlConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public SqlServerConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbConnection GetConnection()
        {

            return new Microsoft.Data.SqlClient.SqlConnection(_configuration.GetConnectionString("SqlServer"));
        }
    }
}
