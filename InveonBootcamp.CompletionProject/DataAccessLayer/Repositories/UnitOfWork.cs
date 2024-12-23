using InveonBootcamp.CompletionProject.Core.Models;
using InveonBootcamp.CompletionProject.DataAccessLayer.Context;

namespace InveonBootcamp.CompletionProject.DataAccessLayer.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Courses = new GenericRepository<Course>(_context);
            Users = new GenericRepository<User>(_context);
            Orders = new GenericRepository<Order>(_context);
            Payments = new GenericRepository<Payment>(_context);
        }

        public IGenericRepository<Course> Courses { get; private set; }
        public IGenericRepository<User> Users { get; private set; }
        public IGenericRepository<Order> Orders { get; private set; }
        public IGenericRepository<Payment> Payments { get; private set; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
