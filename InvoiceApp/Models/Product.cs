using InvoiceApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Models
{
    public class Product : IValidate
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }

        public Product(string name, string description, decimal price, int quantity, string category)
        {
            Name = name;
            Description = description;
            Price = price;
            Quantity = quantity;
            Category = category;
        }

        public bool Validate()
        {
            if (string.IsNullOrEmpty(Name) || Price <= 0 || Quantity < 0 || string.IsNullOrEmpty(Category))
            {
                return false;
            }
            return true;
        }
    }
}
