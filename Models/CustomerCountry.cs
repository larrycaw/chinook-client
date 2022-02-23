using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chinook_client.Models
{
    public class CustomerCountry
    {
        /// <summary>
        /// Property(Country): Countries where customers are located
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Property(AmountOfCustomers): Amount of customers per country
        /// </summary>
        public int AmountOfCustomers { get; set; }
    }
}
