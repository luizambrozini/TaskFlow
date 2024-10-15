using Microsoft.Extensions.DependencyInjection;
using TaskFlow.Application.UseCases.Tasks.CreateTask;

namespace TaskFlow.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection service)
        {
            service.AddScoped<ICreateTaskUseCase, CreateTaskUseCase>();
        }
    }
}
