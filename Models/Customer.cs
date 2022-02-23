using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chinook_client.Models
{
    public class Customer
    {
        /// <summary>
        /// Property(Id): Customers identification number.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Property(FirstName): First name of customer.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Property(LastName): Last name of customer.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Property(Country): Country where customer is located.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Property(PostalCode): Postal code of customers residence.
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// Property(PhoneNumber): Phone number of customer.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Property(Email): Email of customer
        /// </summary>
        public string Email { get; set; }
    }
}
