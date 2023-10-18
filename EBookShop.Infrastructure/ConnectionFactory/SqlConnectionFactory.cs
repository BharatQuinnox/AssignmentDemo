using EBookShop.Core.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace EBookShop.Infrastructure.ConnectionFactory
{
    public class SqlDBConnectionFactory : IDbConnectionFactory
    {
        public IDbConnection CreateConnection(string ConnectionString)
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
