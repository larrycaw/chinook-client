﻿using chinook_client.Models;
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
            InsertCustomer(repository);
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

        static void PrintCustomers(IEnumerable<Customer> customers)
        {
            foreach (Customer customer in customers)
            {
                PrintCustomer(customer);
            }
        }

        static void PrintCustomer(Customer customer)
        {
            Console.WriteLine($"-- { customer.Id} {customer.FirstName} {customer.LastName} {customer.Country} {customer.PostalCode} { customer.PhoneNumber} {customer.Email} --");
        }
    }
}
