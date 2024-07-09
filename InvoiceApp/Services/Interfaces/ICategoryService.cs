using InvoiceApp.Models;


namespace InvoiceApp.Services.Interfaces
{
    public interface ICategoryService
    {
        void AddCategory(Category category);
        void UpdateCategory(string name, Category updatedCategory);
        void DeleteCategory(string name);
        Category GetCategory(string name);
        void ListCategories();
    }
}
