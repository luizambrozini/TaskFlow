using TaskFlow.Comunication.Responses;
using TaskFlow.Data.Repositories;
using TaskFlow.Data.Repositories.Tasks;

namespace TaskFlow.Application.UseCases.Tasks.ListMyTasks
{
    internal class ListMyTasksUseCase : IListMyTasksUseCase
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IUnitOfwork _unitOfwork;

        public ListMyTasksUseCase(ITaskRepository taskRepository, IUnitOfwork unitOfwork)
        {
            _taskRepository = taskRepository;
            _unitOfwork = unitOfwork;
        }

        public ResponseListMyTasksJson Execute()
        {
            var myTasks = _taskRepository.GetAll();
            return new ResponseListMyTasksJson { MyTasks = myTasks };
        }

    }
}
