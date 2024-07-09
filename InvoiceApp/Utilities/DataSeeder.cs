using InvoiceApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace InvoiceApp.Utilities
{
    public class DataSeeder
    {
        public List<Product> Products { get; private set; }
        public List<Category> Categories { get; private set; }
        public List<Customer> Customers { get; private set; }

        public DataSeeder()
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string pFile = Path.Combine(currentDirectory, @"..\..\Resources\products.json"); //dummy data stored in json files
            string cFile = Path.Combine(currentDirectory, @"..\..\Resources\customers.json");
            Products = LoadData<Product>(Path.GetFullPath(pFile));
            Customers = LoadData<Customer>(Path.GetFullPath(cFile));
            Categories = new List<Category>();
            SeedCategories();
        }

        //Loading dummy data from json files
        private List<T> LoadData<T>(string fileName)
        {
            if (!File.Exists(fileName))
            {
                return new List<T>();
            }

            string json = File.ReadAllText(fileName);
            return JsonConvert.DeserializeObject<List<T>>(json);
        }

        //saving user input data to json files
        public void SaveData<T>(List<T> data, string fileName)
        {
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(fileName, json);
        }

        //another way for dummy data seeding
        private void SeedCategories()
        {
            Categories.Add(new Category("Electronics", "Devices and gadgets"));
            Categories.Add(new Category("Books", "Various genres of books"));
            Categories.Add(new Category("Clothing", "kid's clothing"));
        }

        //private void SeedProducts()
        //{
        //    Products.Add(new Product("Laptop", "High performance laptop", 1000.00m, 10, "Electronics"));
        //    Products.Add(new Product("Smartphone", "Latest model smartphone", 800.00m, 15, "mobiles"));
        //    Products.Add(new Product("Novel", "Fiction novel", 20.00m, 50, "Books"));
        //    Products.Add(new Product("T-shirt", "cotton t-shirt", 15.00m, 30, "Clothing"));
        //}

        //private void SeedCustomers()
        //{
        //    Customers.Add(new Customer("A", "A@example.com", "address_A", "1234567890"));
        //    Customers.Add(new Customer("B", "B@example.com", "address_B", "0987654321"));
        //}
    }
}
