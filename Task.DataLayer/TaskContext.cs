using Microsoft.EntityFrameworkCore;
using Task.DataLayer.Entities;

namespace Task.DataLayer
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