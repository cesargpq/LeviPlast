using LeviPlast.Transversal.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;
namespace LeviPlast.Infraestructura.Data
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public ConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection GetConnection
        {
            get
            {
                var sqlConnection = new SqlConnection();
                if (sqlConnection == null) return null;
                sqlConnection.ConnectionString = _configuration.GetConnectionString("NorthwindConnection");
                try
                {
                    sqlConnection.Open();
                }
                catch (Exception ex)
                {
                    var dato = ex.ToString();
                    throw;
                }
                
                return sqlConnection;
            }
        }
    }
}
