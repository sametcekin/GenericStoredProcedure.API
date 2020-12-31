using System.Collections.Generic;
using System.Data;

namespace GenericStoredProcedure.API.Library.DataModel
{
    public class StoredProcedureModel
    {
        public CommandType SqlCommandType { get; set; }

        public string SqlScript { get; set; }

        /// <summary>
        /// Dictionary Key=DatabaseStorredProcedureParamName, Value=C#ParamName
        /// </summary>
        public IDictionary<string, object> Parameters { get; set; }


    }
}
