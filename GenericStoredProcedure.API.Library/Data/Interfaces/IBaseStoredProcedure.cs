using GenericStoredProcedure.API.Library.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GenericStoredProcedure.API.Library.Data.Interfaces
{
    public interface IBaseStoredProcedure
    {
        Task<dynamic> GetStoredProcedureResult(StoredProcedureModel sql);
    }
}
