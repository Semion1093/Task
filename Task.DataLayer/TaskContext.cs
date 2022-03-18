using Microsoft.EntityFrameworkCore;
using TestTask.DataLayer.Entities;

namespace TestTask.DataLayer
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }

        public DbSet<ProjectDto> Projects { get; set; }
        public DbSet<TaskDto> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectDto>()
                .Property(a => a.IsDeleted)
                .HasDefaultValue(0);

            modelBuilder.Entity<TaskDto>()
                .Property(a => a.IsDeleted)
                .HasDefaultValue(0);
        }
    }
}

