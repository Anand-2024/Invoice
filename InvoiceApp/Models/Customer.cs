using InvoiceApp.Models.Interfaces;

namespace InvoiceApp.Models
{
    public class Customer : IValidate
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }

        public Customer(string name, string email, string address, string contactNumber)
        {
            Name = name;
            Email = email;
            Address = address;
            ContactNumber = contactNumber;
        }

        public bool Validate()
        {
            if (string.IsNullOrEmpty(Name) || !Email.Contains("@") || string.IsNullOrEmpty(ContactNumber))
            {
                return false;
            }
            return true;
        }
    }
}
