namespace InveonBootcamp.CompletionProject.Core.Models
{
    public class Course
    {
         public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public double Rating { get; set; }
        public string Instructor { get; set; } = default!;
        public decimal Price { get; set; }
        public string Category { get; set; } = default!;
        public ICollection<OrderCourse> OrderCourses { get; set; }
    }
}
