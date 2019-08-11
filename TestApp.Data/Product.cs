using System.Collections.Generic;

namespace TestApp.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double UnitPrice { get; set; }
        public int AvailableQuantity { get; set; }
        public string ImageUrl { get; set; }

        public static List<Product> DummyProducts()
        {
            List<Product> products = new List<Product>
            {
                new Product() { Id = 1, Name = "Mobile", Category = "Electronic", UnitPrice = 20000, AvailableQuantity = 20, ImageUrl = ""},
                new Product() { Id = 2, Name = "Laptop", Category = "Electronic", UnitPrice = 40000, AvailableQuantity = 10, ImageUrl = ""},
            };

            return products;
        }
    }
}
