using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ReadData
{
    class EmployeeRepository
    {
        private readonly SqlConnection _sqlConnection;
        public EmployeeRepository()
        {
            var connectionString = "data source = (localdb)\\mssqllocaldb; database = AbdulDB";
            _sqlConnection = new SqlConnection(connectionString);
        }
        public IEnumerable<Employee> GetEmployee()
        {
            try
            {
                _sqlConnection.Open();

                var sqlCommand = new SqlCommand("SELECT * FROM Employee", _sqlConnection);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                var employeeList = new List<Employee>();
                while (sqlDataReader.Read())
                {
                    var id = (int)sqlDataReader["Id"];
                    var name = (string)sqlDataReader["Name"];
                    var age = (int)sqlDataReader["Age"];
                    employeeList.Add(new Employee
                    {
                        EmpId = id,
                        EmpName = name,
                        EmpAge = age
                    });
                }
                return employeeList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }
        public Employee GetEmployeeByID(int EmpId)
        {
            try
            {
                _sqlConnection.Open();

                var sqlCommand = new SqlCommand("SELECT * FROM Employee WHERE Id = @Id", _sqlConnection);
                sqlCommand.Parameters.AddWithValue("Id", EmpId);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                var employeeList = new List<Employee>();
                while (sqlDataReader.Read())
                {
                    var id = (int)sqlDataReader["Id"];
                    var name = (string)sqlDataReader["Name"];
                    var age = (int)sqlDataReader["Age"];
                    employeeList.Add(new Employee
                    {
                        EmpId = id,
                        EmpName = name,
                        EmpAge = age
                    });
                }
                return employeeList.FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }
    }
}
