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

            modelBuilder.Entity<Employee>()
                .HasData(
                    new Employee { Id = 1, Name = "Дастан", Surname = "Абишев", Position = "фулл-стэк разработчик" },
                    new Employee { Id = 2, Name = "Диана", Surname = "Левченко", Position = "менеджер проектов" },
                    new Employee { Id = 3, Name = "Диас", Surname = "Адамов", Position = "тестировщик" }
                );
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }
    }
}
