using InvoiceApp.Models;
using InvoiceApp.Services.Interfaces;
using InvoiceApp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InvoiceApp.Services
{
    public class CategoryService : ICategoryService
    {
        private List<Category> _categories;
        private DataSeeder _dataSeeder;

        public CategoryService(List<Category> categories, DataSeeder dataSeeder)
        {
            _categories = categories;
            _dataSeeder = dataSeeder;
        }

        public void AddCategory(Category category)
        {
            _categories.Add(category);
            Console.WriteLine($"Category '{category.Name}' added successfully.");
            _dataSeeder.SaveData(_categories, "categories.json");
        }

        public void UpdateCategory(string name, Category updatedCategory)
        {
            var existingCategory = _categories.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (existingCategory != null)
            {
                existingCategory.Name = updatedCategory.Name;
                existingCategory.Description = updatedCategory.Description;
                Console.WriteLine($"Category '{name}' updated successfully.");
                _dataSeeder.SaveData(_categories, "categories.json");
            }
            else
            {
                Console.WriteLine($"Category '{name}' not found.");
            }
        }

        public void DeleteCategory(string name)
        {
            var categoryToRemove = _categories.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (categoryToRemove != null)
            {
                _categories.Remove(categoryToRemove);
                Console.WriteLine($"Category '{name}' deleted successfully.");
                _dataSeeder.SaveData(_categories, "categories.json");
            }
            else
            {
                Console.WriteLine($"Category '{name}' not found.");
            }
        }

        //probably not usefull
        public Category GetCategory(string name)
        {
            return _categories.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public void ListCategories()
        {
            foreach (var category in _categories)
            {
                Console.WriteLine($"Name: {category.Name}, Description: {category.Description}");
            }
        }
    }
}
