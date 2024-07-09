using InvoiceApp.Models.Interfaces;

namespace InvoiceApp.Models
{
    public class Category : IValidate
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Category(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public bool Validate()
        {
            if (string.IsNullOrEmpty(Name))
            {
                return false;
            }
            return true;
        }
    }
}
