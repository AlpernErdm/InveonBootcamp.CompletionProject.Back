namespace InveonBootcamp.CompletionProject.Core.ExceptionHandler.ExceptionClasses
{
    public class CourseNotFoundException:Exception
    {
        public CourseNotFoundException(int courseId)
            : base($"Course with ID {courseId} not found.")
        { }
    }

    public class CreationFailedException : Exception
    {
        public CreationFailedException(string message)
            : base(message)
        { }
    }

    public class UpdateFailedException : Exception
    {
        public UpdateFailedException(string message)
            : base(message)
        { }
    }

    public class DeletionFailedException : Exception
    {
        public DeletionFailedException(string message)
            : base(message)
        { }
    }
}
