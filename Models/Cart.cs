namespace ECommerceApp.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }
        public string UserId { get; set; } // Ensure this property is not nullable

        public Product Product { get; set; } // Navigation property
    }
}
