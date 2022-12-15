using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace WWDLibrary
{
    public class CustomerRepository
    {
        private readonly SqlConnection _sqlConnection;
        public CustomerRepository()
        {
            var connectionString = "data source = (localdb)\\mssqllocaldb; database = AbdulDB";
            _sqlConnection = new SqlConnection(connectionString);
        }
        public IEnumerable<Customers> ReadCustomers()
        {
            try
            {
                _sqlConnection.Open();

                var sqlCommand = new SqlCommand("SELECT * FROM Customer", _sqlConnection);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                var customersList = new List<Customers>();
                while (sqlDataReader.Read())
                {
                    var id = (int)sqlDataReader["Id"];
                    var name = (string)sqlDataReader["Name"];
                    var age = (int)sqlDataReader["Age"];
                    var city = (string)sqlDataReader["City"];
                    customersList.Add(new Customers
                    {
                        CustId = id,
                        CustName = name,
                        CustAge = age,
                        CustCity = city
                    });
                }
                return customersList;
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
        public bool InsertCustomer(Customers customer)
        {
            try
            {
                _sqlConnection.Open();

                var insertCommand = "INSERT INTO Customer VALUES (@name, @age, @city)";
                var sqlCommand = new SqlCommand(insertCommand, _sqlConnection);

                sqlCommand.Parameters.AddWithValue("name", customer.CustName);
                sqlCommand.Parameters.AddWithValue("age", customer.CustAge);
                sqlCommand.Parameters.AddWithValue("city", customer.CustCity);

                sqlCommand.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }
        public bool UpdateCustomer(Customers customer)
        {
            try
            {
                _sqlConnection.Open();

                var insertCommand = "UPDATE Customer SET Name = @name, Age = @age, City = @city WHERE Id = @id";
                var sqlCommand = new SqlCommand(insertCommand, _sqlConnection);
                sqlCommand.Parameters.AddWithValue("id", customer.CustId);
                sqlCommand.Parameters.AddWithValue("name", customer.CustName);
                sqlCommand.Parameters.AddWithValue("age", customer.CustAge);
                sqlCommand.Parameters.AddWithValue("city", customer.CustCity);

                sqlCommand.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }
        public bool DeleteCustomer(int custId)
        {
            try
            {
                _sqlConnection.Open();

                var insertCommand = "DELETE FROM Customer WHERE Id = @id";
                var sqlCommand = new SqlCommand(insertCommand, _sqlConnection);
                sqlCommand.Parameters.AddWithValue("id", custId);

                sqlCommand.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }
    }
}
