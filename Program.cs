using chinook_client.Models;
using chinook_client.Repositories;
using System;
using System.Collections.Generic;

namespace chinook_client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //All methods were tested through main, below is the last test which tests fetching a customers favourite genre(s)
            ICustomerRepository repository = new CustomerRepository();
            SelectFavoriteGenre(repository, repository.GetCustomerById(12));
        }

        // Fetches from database through the repository and calls print initiation methods
        #region Select Queries
        static void SelectAllCustomers(ICustomerRepository repository)
        {
            PrintCustomers(repository.GetAllCustomers());
        }

        static void SelectCustomerById(ICustomerRepository repository)
        {
            PrintCustomer(repository.GetCustomerById(1));
        }

        static void SelectCustomerByName(ICustomerRepository repository)
        {
            PrintCustomer(repository.GetCustomerByName("%Bjørn%"));
        }

        static void SelectCustomerPage(ICustomerRepository repository)
        {
            PrintCustomers(repository.GetCustomersPage(5, 10));
        }

        static void SelectNumberOfCustomersPerCountry(ICustomerRepository repository)
        {
            PrintCustomerCountries(repository.GetNumberOfCustomersPerCountry());
        }

        static void SelectHighSpenders(ICustomerRepository repository)
        {
            PrintCustomerSpenders(repository.GetHighSpendersDesc());
        }

        static void SelectFavoriteGenre(ICustomerRepository repository, Customer customer)
        {
            PrintFavoriteGenres(repository.GetCustomerFavoriteGenre(customer));
        }
        #endregion

        // Inserts data into the database through the repository
        #region Insert Queries
        static void InsertCustomer(ICustomerRepository repository)
        {
            Customer customer = new Customer()
            {
                FirstName = "Harry",
                LastName = "Potter",
                Country = "England",
                PostalCode = "CH61 1DE",
                PhoneNumber = "(605) 475-6961",
                Email = "harry.potter@student.hogwarts.com"
            };
            if (repository.AddNewCustomer(customer))
            {
                Console.WriteLine("Yay, insert worked");
            }
            else
            {
                Console.WriteLine("Boo!");
            }
        }
        #endregion

        // Updates data in the database through the repositopy
        #region Update Queries
        static void UpdateCustomer(ICustomerRepository repository)
        {
            Customer customer = new Customer()
            {
                Id = 59,
                FirstName = "Ron",
                LastName = "Weasly",
                Country = "England",
                PostalCode = "CH61 2CE",
                PhoneNumber = "(605) 455-6691",
                Email = "ron.weasly@student.hogwarts.com"
            };
            if (repository.UpdateCustomer(customer))
            {
                Console.WriteLine("Yay, update worked");
            }
            else
            {
                Console.WriteLine("Boo!");
            }
        }

        #endregion

        // Loops over data recieved through repository and forwards it for printing to the Console Print Methods
        #region Print initialiser methods
        static void PrintCustomers(IEnumerable<Customer> customers)
        {
            foreach (Customer customer in customers)
            {
                PrintCustomer(customer);
            }
        }

        static void PrintCustomerCountries(IEnumerable<CustomerCountry> customerCountries)
        {
            foreach (CustomerCountry customerCountry in customerCountries)
            {
                PrintCustomerCountry(customerCountry);
            }
        }

        static void PrintCustomerSpenders(IEnumerable<CustomerSpender> customerSpenders)
        {
            foreach(CustomerSpender customerSpender in customerSpenders)
            {
                PrintCustomerSpender(customerSpender);
            }
        }

        static void PrintFavoriteGenres(CustomerGenre customerGenres)
        {
            foreach (String customerGenre in customerGenres.Genres)
            {
                PrintFavoriteGenre(customerGenre);
            }
        }
        #endregion

        // Prints data to the console
        #region Console Print Methods
        static void PrintCustomer(Customer customer)
        {
            Console.WriteLine($"-- { customer.Id} {customer.FirstName} {customer.LastName} {customer.Country} {customer.PostalCode} { customer.PhoneNumber} {customer.Email} --");
        }

        static void PrintCustomerCountry(CustomerCountry customerCountry)
        {
            Console.WriteLine($"-- { customerCountry.Country } { customerCountry.AmountOfCustomers } --");
        }

        static void PrintCustomerSpender(CustomerSpender customerSpender)
        {
            Console.WriteLine($"-- { customerSpender.FullName} { customerSpender.Spending } --");
        }

        static void PrintFavoriteGenre(String customerGenre)
        {
            Console.WriteLine($"-- {customerGenre} --");
        }

        #endregion
    }
}
