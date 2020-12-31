using Dapper;
using GenericStoredProcedure.API.Library.ConnectionFactory.Interfaces;
using GenericStoredProcedure.API.Library.Data.Interfaces;
using GenericStoredProcedure.API.Library.DataModel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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

        private string JSONColumnName { get; set; }
        private IEnumerable<string> ColumnNames { get; set; }

        public async Task<IEnumerable<TEntity>> GetStoredProcedureResult(StoredProcedureModel sql)
        {
            var parameters = new DynamicParameters(sql.Parameters);
            var result = await _connectionFactory.DbConnection().QueryAsync<TEntity>(sql.SqlScript, parameters, commandType: sql.SqlCommandType);

            //foreach (var item in result)
            //{
            //    ColumnNames = ((IDictionary<string, object>)item).Keys.ToArray();
            //    foreach (var column in ColumnNames)
            //    {
            //        if (column.EndsWith("JSON"))
            //        {
            //            Console.WriteLine(column);
            //            JSONColumnName = column;
            //            Versioned.CallByName(item, JSONColumnName, CallType.Set, JsonConvert.DeserializeObject(Versioned.CallByName(item, JSONColumnName, CallType.Get).ToString()));
            //        }
            //    }

            //}
            return result;
        }

    }
}
