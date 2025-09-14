
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription {  get; set; } 
       
        public int Amount {  get; set; } 
        public bool IsAvailable { get; set; }
        public double Rating {  get; set; }
        public decimal Price { get; set; }
        public string PhotoPath { get; set; }

        
        public ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
        public ICollection<ProductColor> ProductColors { get; set; } = new List<ProductColor>();

        public Product(string ProductName,string ProductDescription,int Amount,decimal Price,string PhotoPath)
        {
            this.ProductName = ProductName;
            this.ProductDescription = ProductDescription;
            this.Amount = Amount;
            if (Amount > 0) { IsAvailable = true; } else IsAvailable = false;
                this.Price = Price;
            this.PhotoPath = PhotoPath;
        }
    }
}
