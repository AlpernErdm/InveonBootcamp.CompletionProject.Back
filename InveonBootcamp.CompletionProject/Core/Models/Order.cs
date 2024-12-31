namespace InveonBootcamp.CompletionProject.Core.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }  // User ile ilişkilendirmek için
        public User User { get; set; } = default!;
        public DateTime OrderDate { get; set; }
        public ICollection<OrderCourse> OrderCourses { get; set; } = default!;
        public Payment Payment { get; set; } = default!;
    }
}
