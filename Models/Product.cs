namespace ECommerceApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // Initialize with default value
        public string Description { get; set; } = string.Empty; // Initialize with default value
        public decimal Price { get; set; }
    }
}