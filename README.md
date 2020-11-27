# GenericStoredProcedure.API

#You can change connection strings from appsettings.json
#After changed your connection string if you want to change your database type like Sql,MySql... you have to change GenericStoredProcedure.API.Library/ConnectionFactory/ConnectionFactory.cs 
*
        /// <summary>
        /// There is an Generic DB Connection connection. You can change DefaultConnection from appsettings.json
        /// </summary>
        /// <returns>MySQL connection</returns>
        public IDbConnection DbConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            // return new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            // ...
        }
*

#After this modifications you can post request to the service.
#You can find from properties/launchSettings.json{applicationUrl}

#Example 1 Text SQL
Sql Text post model is
{
    "sqlCommandType":"Text",
    "sqlCommandName":"select * from Table1",
    "parameters":{
        "test":"Data2"
    }
}

Postman result is 
{
  [
    {
        "Id": 1,
        "Column1": "Data1",
        "Column2": "2020-02-02T00:00:00"
    },
    {
        "Id": 2,
        "Column1": "Data1",
        "Column2": "2021-02-02T00:00:00"
    },
    {
        "Id": 3,
        "Column1": "Data2",
        "Column2": "2021-02-02T00:00:00"
    },
    {
        "Id": 4,
        "Column1": "Data2",
        "Column2": "2022-02-02T00:00:00"
    },
    {
        "Id": 5,
        "Column1": "Data3",
        "Column2": "2022-02-03T00:00:00"
    }
]
}
#endExample1

#Example 2 StoredProcedure
Stored Procedure post model is
{
    "sqlCommandType":"StoredProcedure",
    "sqlCommandName":"spc_test",
    "parameters":{
        "test":"Data2"
    }
}

Postman result is
[
    {
        "Id": 3,
        "Column1": "Data2",
        "Column2": "2021-02-02T00:00:00"
    },
    {
        "Id": 4,
        "Column1": "Data2",
        "Column2": "2022-02-02T00:00:00"
    }
]
#endExample2

#Note!!!
Sql Command Types
//
// Summary:
//     An SQL text command. (Default.)
Text = 1,
//
// Summary:
//     The name of a stored procedure.
StoredProcedure = 4,
//
// Summary:
//     The name of a table.
TableDirect = 512
