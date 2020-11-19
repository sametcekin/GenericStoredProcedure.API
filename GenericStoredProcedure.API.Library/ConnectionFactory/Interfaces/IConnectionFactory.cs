using System.Data;

namespace GenericStoredProcedure.API.Library.ConnectionFactory.Interfaces
{
    public interface IConnectionFactory
    {
        IDbConnection DbConnection();
    }
}
