using Microsoft.EntityFrameworkCore;
using TestTask.BusinessLayer.Interfaces;
using TestTask.BusinessLayer.Services;
using TestTask.DataLayer;
using TestTask.DataLayer.Repositories;

namespace TestTask.API.Extensions
{
    public static class BuilderServicesExtensions
    {
        const string connectionEnvironmentVariableName = "CONNECTIONS_STRING";

        public static void AddDbContext(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetValue<string>(connectionEnvironmentVariableName);
            builder.Services.AddDbContext<TaskContext>(op =>
                op.UseSqlServer(connectionString));
        }
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<IProjectService, ProjectService>();
        }
    }
}
