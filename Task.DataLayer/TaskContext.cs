using Microsoft.EntityFrameworkCore;
using TestTask.DataLayer.Entities;
using Task = TestTask.DataLayer.Entities.Task;

namespace TestTask.DataLayer
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .Property(a => a.IsDeleted)
                .HasDefaultValue(0);

            modelBuilder.Entity<Task>()
                .Property(a => a.IsDeleted)
                .HasDefaultValue(0);
        }
    }
}

