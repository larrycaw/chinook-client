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
            ICustomerRepository repository = new CustomerRepository();
            SelectFavoriteGenre(repository);
        }

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

        static void SelectFavoriteGenre(ICustomerRepository repository)
        {
            PrintFavoriteGenres(repository.GetCustomerFavoriteGenre(12));
        }

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
            //foreach(CustomerGenre customerGenre in customerGenres)
            //{
            //    PrintFavoriteGenre(customerGenre);

            foreach (String customerGenre in customerGenres.Genres)
            {
                PrintFavoriteGenre(customerGenre);
            }
        }

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
    }
}
