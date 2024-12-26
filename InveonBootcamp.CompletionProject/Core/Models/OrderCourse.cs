namespace InveonBootcamp.CompletionProject.Core.Models
{
    public class OrderCourse
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; } = default!;
        public int CourseId { get; set; }
        public Course Course { get; set; } = default!;
    }
}
