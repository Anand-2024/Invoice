using System.Collections.Generic;


namespace InvoiceApp.Models
{
    //public class Invoice 
    //{
    //    public Customer Customer { get; set; }
    //    public List<Product> Products { get; set; }
    //    public decimal TotalAmount { get; set; }
    //    public string PaymentOption { get; set; }

    //    public Invoice(Customer customer, List<Product> products, string paymentOption)
    //    {
    //        Customer = customer;
    //        Products = products;
    //        PaymentOption = paymentOption;
    //        TotalAmount = CalculateTotal();
    //    }

    //    public void AddProductToCart(Product product)
    //    {
    //        Products.Add(product);
    //    }

    //    public void RemoveProductFromCart(Product product)
    //    {
    //        Products.Remove(product);
    //    }

    //    public decimal CalculateTotal()
    //    {
    //        decimal total = 0;
    //        foreach (var product in Products)
    //        {
    //            total += product.Price * product.Quantity;
    //        }
    //        return total;
    //    }

    //    public void ApplyDiscount(decimal discount)
    //    {
    //        TotalAmount -= discount;
    //    }

    //    public void GenerateInvoice()
    //    {
    //        // Code to generate invoice
    //    }
    //}
}
