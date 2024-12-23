namespace InveonBootcamp.CompletionProject.Core.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string? Address { get; set; }
        public ICollection<Order> Orders { get; set; } // Navigasyon Özelliği
    }
}
