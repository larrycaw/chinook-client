using chinook_client.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chinook_client.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public bool AddNewCustomer(Customer customer)
        {
            bool success = false;
            string sql = "INSERT INTO Customer(FirstName, LastName, Country, " +
                "PostalCode, Phone, Email) VALUES (@FirstName, @LastName, " +
                "@Country, @PostalCode, @Phone, @Email)";

            try
            {
                using (SqlConnection conn =
                    new SqlConnection(ConnectionHelper.GetConnectionString()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@FirstName",
                            customer.FirstName);
                        cmd.Parameters.AddWithValue("@LastName",
                            customer.LastName);
                        cmd.Parameters.AddWithValue("@Country",
                            customer.Country);
                        cmd.Parameters.AddWithValue("@PostalCode",
                            customer.PostalCode);
                        cmd.Parameters.AddWithValue("@Phone",
                            customer.PhoneNumber);
                        cmd.Parameters.AddWithValue("@Email",
                            customer.Email);
                        success = cmd.ExecuteNonQuery() > 0 ? true : false;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return success;
        }

        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, " +
                "PostalCode, Phone, Email " +
                "FROM Customer";
            try
            {
                // Connect
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionString()))
                {
                    conn.Open();
                    // Make a command
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        // Reader
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Handle result
                                Customer temp = new Customer();
                                temp.Id = reader.GetInt32(0);
                                temp.FirstName = reader.GetString(1);
                                temp.LastName = reader.GetString(2);
                                temp.Country = reader.IsDBNull(3) ? null : reader.GetString(3);
                                temp.PostalCode = reader.IsDBNull(4) ? null : reader.GetString(4);
                                temp.PhoneNumber = reader.IsDBNull(5) ? null : reader.GetString(5);
                                temp.Email = reader.GetString(6);
                                customers.Add(temp);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return customers;
        }

        public Customer GetCustomerById(int id)
        {
            Customer customer = new Customer();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, " +
                "PostalCode, Phone, Email " +
                "FROM Customer " +
                "WHERE CustomerId = @Id";
            try
            {
                using (SqlConnection conn =
                    new SqlConnection(ConnectionHelper.GetConnectionString()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                customer.Id = reader.GetInt32(0);
                                customer.FirstName = reader.GetString(1);
                                customer.LastName = reader.GetString(2);
                                customer.Country = reader.IsDBNull(3) ? null : reader.GetString(3);
                                customer.PostalCode = reader.IsDBNull(4) ? null : reader.GetString(4);
                                customer.PhoneNumber = reader.IsDBNull(5) ? null : reader.GetString(5);
                                customer.Email = reader.GetString(6);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return customer;
        }

        public Customer GetCustomerByName(string name)
        {
            
            Customer customer = new Customer();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, " +
                "PostalCode, Phone, Email " +
                "FROM Customer " +
                "WHERE FirstName + ' ' + LastName LIKE @FullName";
            try
            {
                using (SqlConnection conn =
                    new SqlConnection(ConnectionHelper.GetConnectionString()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@FullName", name);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                customer.Id = reader.GetInt32(0);
                                customer.FirstName = reader.GetString(1);
                                customer.LastName = reader.GetString(2);
                                customer.Country = reader.IsDBNull(3) ? null : reader.GetString(3);
                                customer.PostalCode = reader.IsDBNull(4) ? null : reader.GetString(4);
                                customer.PhoneNumber = reader.IsDBNull(5) ? null : reader.GetString(5);
                                customer.Email = reader.GetString(6);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return customer;
        }

        public CustomerGenre GetCustomerFavoriteGenre()
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetCustomersPage(int offset, int limit)
        {
            List<Customer> customers = new List<Customer>();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email " +
                "FROM Customer " +
                "ORDER BY CustomerId " +
                "OFFSET @Offset ROWS FETCH NEXT @Limit ROWS ONLY";

            try
            {
                // Connect
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionString()))
                {
                    conn.Open();
                    // Make a command
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Limit", limit);
                        cmd.Parameters.AddWithValue("@Offset", offset);
                        // Reader
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Handle result
                                Customer temp = new Customer();
                                temp.Id = reader.GetInt32(0);
                                temp.FirstName = reader.GetString(1);
                                temp.LastName = reader.GetString(2);
                                temp.Country = reader.IsDBNull(3) ? null : reader.GetString(3);
                                temp.PostalCode = reader.IsDBNull(4) ? null : reader.GetString(4);
                                temp.PhoneNumber = reader.IsDBNull(5) ? null : reader.GetString(5);
                                temp.Email = reader.GetString(6);
                                customers.Add(temp);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return customers;
        }

        public List<CustomerSpender> GetHighSpendersDesc()
        {
            throw new NotImplementedException();
        }

        public List<CustomerCountry> GetNumberOfCustomersPerCountry()
        {
            List<CustomerCountry> customers = new List<CustomerCountry>();
            string sql = "SELECT Country, COUNT(CustomerId) AS Customers " +
                "FROM Customer " +
                "GROUP BY Country " +
                "ORDER BY Customers DESC";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionString()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerCountry temp = new CustomerCountry();
                                temp.Country = reader.GetString(0);
                                temp.AmountOfCustomers = reader.GetInt32(1);
                                customers.Add(temp);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return customers;
        }

        public bool UpdateCustomer(Customer customer)
        {
            bool success = false;
            string sql = "UPDATE Customer SET FirstName = @FirstName, " +
                "LastName = @LastName, Country = @Country, " +
                "PostalCode = @PostalCode, Phone = @Phone, Email = @Email " +
                "WHERE CustomerId = @CustomerId";

            try
            {
                using (SqlConnection conn =
                    new SqlConnection(ConnectionHelper.GetConnectionString()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@FirstName",
                            customer.FirstName);
                        cmd.Parameters.AddWithValue("@LastName",
                            customer.LastName);
                        cmd.Parameters.AddWithValue("@Country",
                            customer.Country);
                        cmd.Parameters.AddWithValue("@PostalCode",
                            customer.PostalCode);
                        cmd.Parameters.AddWithValue("@Phone",
                            customer.PhoneNumber);
                        cmd.Parameters.AddWithValue("@Email",
                            customer.Email);
                        cmd.Parameters.AddWithValue("@CustomerId",
                            customer.Id);
                        success = cmd.ExecuteNonQuery() > 0 ? true : false;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return success;
        }
    }
}
