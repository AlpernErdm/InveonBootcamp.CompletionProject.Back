namespace InveonBootcamp.CompletionProject.Core.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; } = default!;
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public ICollection<OrderCourse> OrderCourses { get; set; } = new List<OrderCourse>();
        public Payment Payment { get; set; } = default!;
    }
}
