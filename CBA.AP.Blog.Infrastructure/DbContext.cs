using System.Data;
using MySql.Data.MySqlClient;

namespace CBA.AP.Blog.Infrastructure
{
    public class DbContext
    {
        private readonly string ConnectionString;

        public DbContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public IDbConnection GetConnection()
        {
            return new MySqlConnection(this.ConnectionString);
        }
    }
}