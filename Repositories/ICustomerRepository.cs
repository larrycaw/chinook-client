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
    }
}
