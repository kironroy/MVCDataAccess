using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataLibrary.DataAccess
{
    // this class is where the actual data access to the datbabse occurs 
    // this class is static because it doesn't store data
    public static class SqlDataAccess
    {
        public static string GetConnectionString(string connectionName = "MVCDemoDB")
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

       // 1. load data
       // 2. here is the model to load into (T)
       // 3. return back a list of that model (T)
       // 4. connect to this sql, give me this sql
       // 5. execute that sql and load that query into type T
       // 6. query returns INumerable
       // 7. convert INumerable to List
       // 8. _done_

        public static List<T> LoadData<T>(string sql) 
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<T>(sql).ToList();
            }
        }

        public static int SaveData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Execute(sql, data);
            }
        }
    }
}
