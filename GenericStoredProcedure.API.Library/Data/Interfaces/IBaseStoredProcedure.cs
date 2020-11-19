using GenericStoredProcedure.API.Library.DataModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenericStoredProcedure.API.Library.Data.Interfaces
{
    public interface IBaseStoredProcedure<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetStoredProcedureResult(StoredProcedureModel sql);
    }
}
