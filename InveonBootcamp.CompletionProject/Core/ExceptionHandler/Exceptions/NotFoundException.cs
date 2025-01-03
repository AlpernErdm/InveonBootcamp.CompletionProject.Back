namespace InveonBootcamp.CompletionProject.Core.ExceptionHandler.ExceptionClasses
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) { }
    }
}
