using InvoiceApp.Models;

namespace InvoiceApp.Services.Interfaces
{
    public interface ICustomerService
    {
        void AddCustomer(Customer customer);
        void UpdateCustomer(string name, Customer updatedCustomer);
        void DeleteCustomer(string name);
        Customer GetCustomer(string name);
        void ListCustomers();
    }
}
