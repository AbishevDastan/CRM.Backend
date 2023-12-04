using Domain.Entities;
using Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new EmployeeConfiguration().Configure(modelBuilder.Entity<Employee>());
            new TaskItemConfiguration().Configure(modelBuilder.Entity<TaskItem>());
            new AdminConfiguration().Configure(modelBuilder.Entity<Admin>());

            modelBuilder.Entity<Employee>()
                .HasData(
                    new Employee { Id = 1, FullName = "Дастан Абишев", Position = "фулл-стэк разработчик" },
                    new Employee { Id = 2, FullName = "Диана Левченко", Position = "менеджер проектов" },
                    new Employee { Id = 3, FullName = "Диас Адамов", Position = "тестировщик" }
                );
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
