using System;
using System.Collections.Generic;
using System.Text;

namespace GenericStoredProcedure.API.Library.DataModel
{
    public class StoredProcedureModel
    {
        public string StoredProcedureName { get; set; }

        /// <summary>
        /// Dictionary Key=DatabaseStorredProcedureParamName, Value=C#ParamName
        /// </summary>
        public IDictionary<string, object> Parameters { get; set; }

    }
}
