using Microsoft.Extensions.DependencyInjection;
using TaskFlow.Application.UseCases.Tasks.CreateTask;
using TaskFlow.Application.UseCases.Tasks.GetTask;
using TaskFlow.Application.UseCases.Tasks.ListMyTasks;

namespace TaskFlow.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection service)
        {
            service.AddScoped<IListMyTasksUseCase, ListMyTasksUseCase>();
            service.AddScoped<IGetMyTaskByIdUseCase, GetMyTaskByIdUseCase>();
            service.AddScoped<ICreateTaskUseCase, CreateTaskUseCase>();
        }
    }
}
