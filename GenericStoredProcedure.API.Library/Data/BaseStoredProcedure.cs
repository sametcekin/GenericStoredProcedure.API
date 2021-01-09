using Dapper;
using GenericStoredProcedure.API.Library.ConnectionFactory.Interfaces;
using GenericStoredProcedure.API.Library.Data.Interfaces;
using GenericStoredProcedure.API.Library.DataModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenericStoredProcedure.API.Library.Data
{
    public class BaseStoredProcedure<TEntity> : IBaseStoredProcedure<TEntity> where TEntity : class
    {
        private readonly IConnectionFactory _connectionFactory;

        public BaseStoredProcedure(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<TEntity>> GetStoredProcedureResult(StoredProcedureModel sql)
        {
            var parameters = new DynamicParameters(sql.Parameters);
            var result = await _connectionFactory.DbConnection().QueryAsync<TEntity>(sql.SqlScript, parameters, commandType: sql.SqlCommandType);
            return result;
        }

    }
}
