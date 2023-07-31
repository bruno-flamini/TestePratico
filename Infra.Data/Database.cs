using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace TestePratico.Infra.Data
{
    public class Database
    {
        protected SqlConnection _connection;

        public Database()
        {
            ConfigurarDatabase();
        }

        private void ConfigurarDatabase()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", true, true)
                .Build();

            _connection = new SqlConnection(builder.GetConnectionString("DefaultConnection"));
        }
    }
}
