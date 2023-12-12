using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;

namespace TaskAPI.Data
{
    public class TaskContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public TaskContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("TaskDBConnection");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
