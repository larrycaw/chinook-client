using chinook_client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chinook_client.Repositories
{
    public interface ICustomerRepository
    {
        /// <summary>
        /// Fetch all customers from database.
        /// </summary>
        /// <returns>List containing all customers</returns>
        public List<Customer> GetAllCustomers();

        public Customer GetCustomerById(int id);

        public Customer GetCustomerByName(string name);

        public List<Customer> GetCustomersPage(int limit, int offset);

        public bool AddNewCustomer(Customer customer);

        public bool UpdateCustomer(Customer customer);

        public List<CustomerCountry> GetNumberOfCustomersPerCountry();

        public List<CustomerSpender> GetHighSpendersDesc();

        public CustomerGenre GetCustomerFavoriteGenre(int id);
    }
}
