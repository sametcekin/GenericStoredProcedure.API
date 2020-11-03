using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace GenericStoredProcedure.API.Library.DataModel
{
    public class StoredProcedureModel
    {
        public CommandType SqlCommandType { get; set; }

        public string SqlCommandName { get; set; }

        /// <summary>
        /// Dictionary Key=DatabaseStorredProcedureParamName, Value=C#ParamName
        /// </summary>
        public IDictionary<string, object> Parameters { get; set; }


    }
}
