using System.Data;

namespace EBookShop.Core.Interfaces
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection(string ConnectionString);
    }
}
