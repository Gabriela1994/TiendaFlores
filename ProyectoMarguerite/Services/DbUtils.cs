using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ProyectoMarguerite.Services
{
    public class DbUtils
    {

        public static SqlConnection RecuperarConnection()
        {
            var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
            var config = builder.Build();

            string connectionString = config.GetConnectionString("DefaultConnection");

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            return conn;

        }
    }
}
