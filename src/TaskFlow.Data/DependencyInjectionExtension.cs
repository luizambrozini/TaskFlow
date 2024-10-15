using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskFlow.Data.Contexts;
using TaskFlow.Data.Repositories;
using TaskFlow.Data.Repositories.Tasks;

namespace TaskFlow.Data
{
    public static class DependencyInjectionExtension
    {
        public static void AddData(this IServiceCollection services, IConfiguration configuration)
        {
            AddDbContext(services, configuration);
            AddRepositories(services);
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<IUnitOfwork, UnitOfwork>();
        }

        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("TaskFlow");

            services.AddDbContext<TaskFlowDbContext>(options =>
            {
                options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 4, 2)));
            });
        }
    }
}
