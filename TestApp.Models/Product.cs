
namespace TestApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public double UnitPrice { get; set; }
        public int AvailableQuantity { get; set; }
        public string ImageUrl { get; set; }
    }
}
