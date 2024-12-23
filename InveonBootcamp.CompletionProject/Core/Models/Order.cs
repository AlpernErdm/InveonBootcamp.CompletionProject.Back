namespace InveonBootcamp.CompletionProject.Core.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Guid UserId { get; set; } // UserId ile User'ı ilişkilendiriyoruz
        public User User { get; set; }
        public DateTime OrderDate { get; set; }
        public ICollection<OrderCourse> OrderCourses { get; set; }
    }
}
