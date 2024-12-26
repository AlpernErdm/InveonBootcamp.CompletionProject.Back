using InveonBootcamp.CompletionProject.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace InveonBootcamp.CompletionProject.DataAccessLayer.Context
{
    public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
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

            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Payment)
                .WithOne(p => p.Order)
                .HasForeignKey<Payment>(p => p.OrderId);

            // Payment Amount için hassasiyet ve ölçek belirleme
            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasColumnType("decimal(18,2)");

            base.OnModelCreating(modelBuilder);
        }
    }
}
