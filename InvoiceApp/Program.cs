using InvoiceApp.Models;
using InvoiceApp.Services;
using InvoiceApp.Services.Interfaces;
using InvoiceApp.Utilities;
using System;
using System.Collections.Generic;

namespace InvoiceApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSeeder dataSeeder = new DataSeeder();
            IProductService productService = new ProductService(dataSeeder.Products, dataSeeder);
            ICustomerService customerService = new CustomerService(dataSeeder.Customers, dataSeeder);
            ICategoryService categoryService = new CategoryService(dataSeeder.Categories, dataSeeder); //seeding data from seeder class instead of json

            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Invoicing System");
                Console.WriteLine("1. Manage Products");
                Console.WriteLine("2. Manage Categories");
                Console.WriteLine("3. Manage Customers");
                Console.WriteLine("4. Create Invoice");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        ManageProducts(productService);
                        break;
                    case "2":
                        ManageCategories(categoryService);
                        break;
                    case "3":
                        ManageCustomers(customerService);
                        break;
                    case "4":
                        CreateInvoice(customerService, productService);
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
                //Console.ReadLine();
            }
        }

        static void ManageProducts(IProductService productService)
        {
            Console.WriteLine("Products Menu");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Update Product");
            Console.WriteLine("3. Delete Product");
            Console.WriteLine("4. List Products");
            Console.Write("Select an option: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter Product Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter Product Description: ");
                    string description = Console.ReadLine();
                    Console.Write("Enter Product Price: ");
                    decimal price = decimal.Parse(Console.ReadLine());
                    Console.Write("Enter Product Quantity: ");
                    int quantity = int.Parse(Console.ReadLine());
                    Console.Write("Enter Product Category: ");
                    string category = Console.ReadLine();
                    productService.AddProduct(new Product(name, description, price, quantity, category));
                    break;
                case "2":
                    Console.Write("Enter Product Name to Update: ");
                    string productName = Console.ReadLine();
                    Console.Write("Enter New Product Name: ");
                    string newName = Console.ReadLine();
                    Console.Write("Enter New Product Description: ");
                    string newDescription = Console.ReadLine();
                    Console.Write("Enter New Product Price: ");
                    decimal newPrice = decimal.Parse(Console.ReadLine());
                    Console.Write("Enter New Product Quantity: ");
                    int newQuantity = int.Parse(Console.ReadLine());
                    Console.Write("Enter New Product Category: ");
                    string newCategory = Console.ReadLine();
                    productService.UpdateProduct(productName, new Product(newName, newDescription, newPrice, newQuantity, newCategory));
                    break;
                case "3":
                    Console.Write("Enter Product Name to Delete: ");
                    productName = Console.ReadLine();
                    productService.DeleteProduct(productName);
                    break;
                case "4":
                    Console.WriteLine("List of Products:");
                    productService.ListProducts();
                    break;
                default:
                    Console.WriteLine();
                    break;
            }

            Console.ReadLine();
        }

        static void ManageCategories(ICategoryService categoryService)
        {
            Console.WriteLine("Categories Menu");
            Console.WriteLine("1. Add Category");
            Console.WriteLine("2. Update Category");
            Console.WriteLine("3. Delete Category");
            Console.WriteLine("4. List Categories");
            Console.Write("Select an option: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter Category Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter Category Description: ");
                    string description = Console.ReadLine();
                    categoryService.AddCategory(new Category(name, description));
                    break;
                case "2":
                    Console.Write("Enter Category Name to Update: ");
                    string categoryName = Console.ReadLine();
                    Console.Write("Enter New Category Name: ");
                    string newName = Console.ReadLine();
                    Console.Write("Enter New Category Description: ");
                    string newDescription = Console.ReadLine();
                    categoryService.UpdateCategory(categoryName, new Category(newName, newDescription));
                    break;
                case "3":
                    Console.Write("Enter Category Name to Delete: ");
                    categoryName = Console.ReadLine();
                    categoryService.DeleteCategory(categoryName);
                    break;
                case "4":
                    Console.WriteLine("List of Categories:");
                    categoryService.ListCategories();
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static void ManageCustomers(ICustomerService customerService)
        {
            Console.WriteLine("Customers Menu");
            Console.WriteLine("1. Add Customer");
            Console.WriteLine("2. Update Customer");
            Console.WriteLine("3. Delete Customer");
            Console.WriteLine("4. List Customers");
            Console.Write("Select an option: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter Customer Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter Customer Email: ");
                    string email = Console.ReadLine();
                    Console.Write("Enter Customer Address: ");
                    string address = Console.ReadLine();
                    Console.Write("Enter Customer Contact Number: ");
                    string contactNumber = Console.ReadLine();
                    customerService.AddCustomer(new Customer(name, email, address, contactNumber));
                    break;
                case "2":
                    Console.Write("Enter Customer Name to Update: ");
                    string customerName = Console.ReadLine();
                    Console.Write("Enter New Customer Name: ");
                    string newName = Console.ReadLine();
                    Console.Write("Enter New Customer Email: ");
                    string newEmail = Console.ReadLine();
                    Console.Write("Enter New Customer Address: ");
                    string newAddress = Console.ReadLine();
                    Console.Write("Enter New Customer Contact Number: ");
                    string newContactNumber = Console.ReadLine();
                    customerService.UpdateCustomer(customerName, new Customer(newName, newEmail, newAddress, newContactNumber));
                    break;
                case "3":
                    Console.Write("Enter Customer Name to Delete: ");
                    customerName = Console.ReadLine();
                    customerService.DeleteCustomer(customerName);
                    break;
                case "4":
                    Console.WriteLine("List of Customers:");
                    customerService.ListCustomers();
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static void CreateInvoice(ICustomerService customerService, IProductService productService)
        {
            // Implement invoice creation logic here
            Console.WriteLine("Creating invoice...");

            // Get customer information
            Console.Write("Enter Customer Name: ");
            string customerName = Console.ReadLine();
            var customer = customerService.GetCustomer(customerName);

            if (customer == null)
            {
                Console.WriteLine("Customer not found.");
                return;
            }

            // Initialize invoice
            List<Product> cart = new List<Product>();
            bool addingProducts = true;

            while (addingProducts)
            {
                Console.WriteLine("Add Product to Cart (type 'done' when finished)");
                Console.Write("Enter Product Name: ");
                string productName = Console.ReadLine();

                if (productName.ToLower() == "done")
                {
                    addingProducts = false;
                    break;
                }

                var product = productService.GetProduct(productName);
                if (product != null)
                {
                    cart.Add(product);
                    Console.WriteLine("Product added to cart.");
                }
                else
                {
                    Console.WriteLine("Product not found.");
                }
            }

            // Select payment option
            Console.WriteLine("Select Payment Option:");
            Console.WriteLine("1. Cash");
            Console.WriteLine("2. Credit Card");
            Console.Write("Enter payment option (1 or 2): ");
            string paymentOption = Console.ReadLine();

            if (paymentOption == "1")
            {
                paymentOption = "Cash";
            }
            else if (paymentOption == "2")
            {
                paymentOption = "Credit Card";
            }
            else
            {
                Console.WriteLine("Invalid payment option.");
                return;
            }

            // Generate and display invoice
            decimal totalAmount = 0;
            Console.WriteLine("\nInvoice:");
            Console.WriteLine($"Customer: {customer.Name}, Address: {customer.Address}, Contact Number: {customer.ContactNumber}");
            Console.WriteLine("Products Purchased:");
            foreach (var item in cart)
            {
                Console.WriteLine($"Name: {item.Name}, Price: {item.Price}, Quantity: {item.Quantity}");
                totalAmount += item.Price * item.Quantity;
            }
            //ignored discounts calculation

            Console.WriteLine($"Total Amount: {totalAmount}");
            Console.WriteLine($"Payment Option: {paymentOption}");

            Console.WriteLine("\nInvoice generated successfully.");

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }
    }
}
