using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chinook_client.Models
{
    public class CustomerSpender
    {
        /// <summary>
        /// Property(FullName): Is a concatenation of FirstName and LastName.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Property(Spending): Amount of money spent.
        /// </summary>
        public decimal? Spending { get; set; }
    }
}
