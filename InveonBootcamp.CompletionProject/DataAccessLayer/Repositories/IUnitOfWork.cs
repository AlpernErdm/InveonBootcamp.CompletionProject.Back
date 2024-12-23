using InveonBootcamp.CompletionProject.Core.Models;

namespace InveonBootcamp.CompletionProject.DataAccessLayer.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Course> Courses { get; }
        IGenericRepository<User> Users { get; }
        IGenericRepository<Order> Orders { get; }
        IGenericRepository<Payment> Payments { get; }
        Task<int> CompleteAsync();
    }
}
