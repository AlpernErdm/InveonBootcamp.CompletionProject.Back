namespace InveonBootcamp.CompletionProject.Core.Models
{
    public class User
    {
        public Guid Id { get; set; }=Guid.NewGuid();
        public string Username { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string  Email { get; set; } = default!;
        public  string  Role { get; set; }
        public string PhoneNumber { get; set; } = default!;
        public ICollection<Order> Orders { get; set; } = default!;
    }
}
