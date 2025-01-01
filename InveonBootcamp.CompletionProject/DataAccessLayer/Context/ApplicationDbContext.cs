using InveonBootcamp.CompletionProject.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace InveonBootcamp.CompletionProject.DataAccessLayer.Context
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<OrderCourse> OrderCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderCourse>()
                .HasKey(oc => new { oc.OrderId, oc.CourseId });

            modelBuilder.Entity<OrderCourse>()
                .HasOne(oc => oc.Order)
                .WithMany(o => o.OrderCourses)
                .HasForeignKey(oc => oc.OrderId);

            modelBuilder.Entity<OrderCourse>()
                .HasOne(oc => oc.Course)
                .WithMany(c => c.OrderCourses)
                .HasForeignKey(oc => oc.CourseId);

            modelBuilder.Entity<Course>()
                .Property(c => c.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<User>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Payment)
                .WithOne(p => p.Order)
                .HasForeignKey<Payment>(p => p.OrderId);

            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasColumnType("decimal(18,2)");

            var users = new List<User>();
            for (int i = 1; i <= 20; i++)
            {
                users.Add(new User
                {
                    Id = Guid.NewGuid(),
                    Username = "testuser" + i,
                    Password = "password" + i,
                    Email = "test" + i + "@example.com",
                    PhoneNumber = "123456789" + i
                });
            }
            modelBuilder.Entity<User>().HasData(users);

            // Seed Courses
            var courses = new List<Course>();
            for (int i = 1; i <= 20; i++)
            {
                courses.Add(new Course
                {
                    Id = i,
                    Name = "Course " + i,
                    Description = "Description " + i,
                    Rating = 4.0 + (i % 5) * 0.1,
                    Instructor = "Instructor " + i,
                    Price = 100 + (i * 10),
                    Category = "Category " + i % 5
                });
            }
            modelBuilder.Entity<Course>().HasData(courses);

            // Seed Orders
            var orders = new List<Order>();
            for (int i = 1; i <= 20; i++)
            {
                orders.Add(new Order
                {
                    Id = i,
                    UserId = users[i % users.Count].Id,
                    OrderDate = DateTime.Now.AddDays(-i)
                });
            }
            modelBuilder.Entity<Order>().HasData(orders);

            // Seed Payments
            var payments = new List<Payment>();
            for (int i = 1; i <= 20; i++)
            {
                payments.Add(new Payment
                {
                    Id = i,
                    PaymentStatus = "Completed",
                    Amount = 100 + i * 10,
                    PaymentDate = DateTime.Now.AddDays(-i),
                    OrderId = i
                });
            }
            modelBuilder.Entity<Payment>().HasData(payments);

            // Seed OrderCourses (each order contains two courses)
            var orderCourses = new List<OrderCourse>();
            for (int i = 1; i <= 20; i++)
            {
                orderCourses.Add(new OrderCourse
                {
                    OrderId = i,
                    CourseId = (i * 2 - 1) % 20 + 1
                });
                orderCourses.Add(new OrderCourse
                {
                    OrderId = i,
                    CourseId = (i * 2) % 20 + 1
                });
            }
            modelBuilder.Entity<OrderCourse>().HasData(orderCourses);
        }
    }
    }
