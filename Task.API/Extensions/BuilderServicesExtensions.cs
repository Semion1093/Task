using Task.BusinessLayer.Interfaces;
using Task.BusinessLayer.Services;
using Task.DataLayer.Repositories;

namespace Task.API.Extensions
{
    public static class BuilderServicesExtensions
    {
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
