using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace InvoiceTracker.Persistence.Context
{
    public class DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("localDb") ?? throw new ArgumentNullException("Connection string not found.");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
