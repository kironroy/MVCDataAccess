using DataLibrary.DataAccess;
using DataLibrary.Models;
using System.Collections.Generic;

namespace DataLibrary.BusinessLogic
{
    // this class is static, not storing data
    public static class EmployeeProcessor
    {
        public static int CreateEmployee(int employeeId, string firstName, 
            string lastName, string emailAddress)
        {
            // mapped one model to another model
            EmployeeModel data = new EmployeeModel
            {
                EmployeeId = employeeId,
                FirstName = firstName,
                LastName = lastName,
                EmailAddress = emailAddress
            };

            // insert to database
             // the sql statement
            string sql = @"Insert into dbo.Employee (EmployeeID, FirstName, LastName, EmailAddress)
                           values(@EmployeeId, @FirstName, @LastName, @EmailAddress);";

            return SqlDataAccess.SaveData(sql, data);
        }

        // this is the Business logic data access Employee Model
        public static List<EmployeeModel> LoadEmployees()
        {
            // this statement just returns everything
            string sql = @"select Id, EmployeeId, FirstName, LastName, EmailAddress
                         from dbo.Employee;";

            // load all our employees back
            return SqlDataAccess.LoadData<EmployeeModel>(sql);
        }
    }
}
