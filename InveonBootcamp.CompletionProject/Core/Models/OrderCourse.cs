namespace InveonBootcamp.CompletionProject.Core.Models
{
    public class OrderCourse
    {
        public int OrderId { get; set; }
        public required Order Order { get; set; }
        public int CourseId { get; set; }
        public required Course Course { get; set; }
    }
}
