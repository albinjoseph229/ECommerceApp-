namespace ECommerceApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty; // Initialize with default value
        public string Password { get; set; } = string.Empty; // Initialize with default value
        public string Email { get; set; } = string.Empty; // Initialize with default value
    }
}