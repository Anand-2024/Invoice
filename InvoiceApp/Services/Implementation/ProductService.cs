using InvoiceApp.Models;
using InvoiceApp.Services.Interfaces;
using InvoiceApp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InvoiceApp.Services
{
    public class ProductService : IProductService
    {
        private List<Product> _products;
        private DataSeeder _dataSeeder;

        public ProductService(List<Product> products, DataSeeder dataSeeder)
        {
            _products = products;
            _dataSeeder = dataSeeder;
        }

        public void AddProduct(Product product)
        {
            //ignored validation
            try
            {
                _products.Add(product);
                Console.WriteLine($"Product '{product.Name}' added successfully.");
                _dataSeeder.SaveData(_products, "products.json");
            }
            catch (Exception ex)
            {

                //log exception
            }
        }

        public void UpdateProduct(string name, Product updatedProduct)
        {
            var existingProduct = _products.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (existingProduct != null)
            {
                existingProduct.Name = updatedProduct.Name;
                existingProduct.Description = updatedProduct.Description;
                existingProduct.Price = updatedProduct.Price;
                existingProduct.Quantity = updatedProduct.Quantity;
                existingProduct.Category = updatedProduct.Category;
                Console.WriteLine($"Product '{name}' updated successfully.");
                _dataSeeder.SaveData(_products, "products.json");
            }
            else
            {
                Console.WriteLine($"Product '{name}' not found.");
            }
        }

        public void DeleteProduct(string name)
        {
            try
            {
                var productToRemove = _products.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                if (productToRemove != null)
                {
                    _products.Remove(productToRemove);
                    Console.WriteLine($"Product '{name}' deleted successfully.");
                    _dataSeeder.SaveData(_products, "products.json");
                }
                else
                {
                    Console.WriteLine($"Product '{name}' not found.");
                }
            }
            catch (Exception ex)
            {

                //log exception
            }
        }

        public Product GetProduct(string name)
        {
            return _products.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public void ListProducts()
        {
            foreach (var product in _products)
            {
                Console.WriteLine($"Name: {product.Name}, Description: {product.Description}, Price: {product.Price}, Quantity: {product.Quantity}, Category: {product.Category}");
            }
        }
    }
}
