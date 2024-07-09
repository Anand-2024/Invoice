using System;
using System.Collections.Generic;
using System.Linq;
using InvoiceApp.Models;
using InvoiceApp.Services.Interfaces;
using InvoiceApp.Utilities;

namespace InvoiceApp.Services
{
    public class CustomerService : ICustomerService
    {
        private List<Customer> _customers;
        private DataSeeder _dataSeeder;

        public CustomerService(List<Customer> initialCustomers, DataSeeder dataSeeder)
        {
            _customers = initialCustomers;
            _dataSeeder = dataSeeder;
        }

        public void AddCustomer(Customer customer)
        {
            try
            {
                _customers.Add(customer);
                Console.WriteLine($"Customer '{customer.Name}' added successfully.");
                _dataSeeder.SaveData(_customers, "customers.json");
            }
            catch (Exception ex)
            {

                //log exception
            }
        }

        public void UpdateCustomer(string name, Customer updatedCustomer)
        {
            var existingCustomer = _customers.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (existingCustomer != null)
            {
                existingCustomer.Name = updatedCustomer.Name;
                existingCustomer.Email = updatedCustomer.Email;
                existingCustomer.Address = updatedCustomer.Address;
                existingCustomer.ContactNumber = updatedCustomer.ContactNumber;
                Console.WriteLine($"Customer '{name}' updated successfully.");
                _dataSeeder.SaveData(_customers, "customers.json");
            }
            else
            {
                Console.WriteLine($"Customer '{name}' not found.");
            }
        }

        public void DeleteCustomer(string name)
        {
            try
            {
                var customerToRemove = _customers.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                if (customerToRemove != null)
                {
                    _customers.Remove(customerToRemove);
                    Console.WriteLine($"Customer '{name}' deleted successfully.");
                    _dataSeeder.SaveData(_customers, "customers.json");
                }
                else
                {
                    Console.WriteLine($"Customer '{name}' not found.");
                }
            }
            catch (Exception ex)
            {

                //log exception
            }
        }

        public Customer GetCustomer(string name)
        {
            return _customers.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public void ListCustomers()
        {
            foreach (var customer in _customers)
            {
                Console.WriteLine($"Name: {customer.Name}, Email: {customer.Email}, Address: {customer.Address}, Contact Number: {customer.ContactNumber}");
            }
        }
    }
}

