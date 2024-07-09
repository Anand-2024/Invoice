using InvoiceApp.Models;


namespace InvoiceApp.Services.Interfaces
{
    public interface IProductService
    {
        void AddProduct(Product product);
        void UpdateProduct(string name, Product updatedProduct);
        void DeleteProduct(string name);
        Product GetProduct(string name);
        void ListProducts();
    }
}
