using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;

namespace RollForQuirk.Repositories
{
    public abstract class BaseRepository
    {
        public readonly string _connectionString;

        public BaseRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Defaultconnection");
        }

        protected SqlConnection Connection
        {
            get 
            {
                return new SqlConnection(_connectionString); 
            }
        }
    }
}
