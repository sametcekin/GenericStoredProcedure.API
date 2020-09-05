using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace GenericStoredProcedure.API.Library.ConnectionFactory.Interfaces
{
    public interface IConnectionFactory
    {
        IDbConnection DbConnection();
    }
}
