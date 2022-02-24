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

        /// <summary>
        /// Fetch a customer by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A single customer</returns>
        public Customer GetCustomerById(int id);

        /// <summary>
        /// Fetch a customer by name. In case of multiple matches, returns last match.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>A single customer matching the name argument</returns>
        public Customer GetCustomerByName(string name);

        /// <summary>
        /// Fetch a paginated set of customers based on given arguments
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns>List of customers</returns>
        public List<Customer> GetCustomersPage(int limit, int offset);

        /// <summary>
        /// Adds a new customer to the database
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>True if insert was successfull</returns>
        public bool AddNewCustomer(Customer customer);

        /// <summary>
        /// Updates details of a given customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>True if update was successfull</returns>
        public bool UpdateCustomer(Customer customer);

        /// <summary>
        /// Gets a list with number of customers per country in descending order
        /// </summary>
        /// <returns>List of CustomerCountry</returns>
        public List<CustomerCountry> GetNumberOfCustomersPerCountry();

        /// <summary>
        /// Fetch a list of customer spending in descending order
        /// </summary>
        /// <returns>List of CustomerSpender</returns>
        public List<CustomerSpender> GetHighSpendersDesc();

        /// <summary>
        /// Fetch the most popular genre for a customer, defined by how many times a genre appears on the customers invoices.
        /// In case of a tie, fetches all genres with maximum occurences.
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>A CustomerGenre object containing the customers full name and a list of genres</returns>
        public CustomerGenre GetCustomerFavoriteGenre(Customer customer);
    }
}
