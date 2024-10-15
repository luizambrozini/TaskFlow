using TaskFlow.Application.Exceptions.ExceptionsBase;
using TaskFlow.Comunication.Requests;
using TaskFlow.Comunication.Responses;
using TaskFlow.Data.Entities;
using TaskFlow.Data.Repositories;
using TaskFlow.Data.Repositories.Tasks;

namespace TaskFlow.Application.UseCases.Tasks.CreateTask
{
    internal class CreateTaskUseCase : ICreateTaskUseCase
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IUnitOfwork _unitOfwork;

        public CreateTaskUseCase(ITaskRepository taskRepository, IUnitOfwork unitOfwork)
        {
            _taskRepository = taskRepository;
            _unitOfwork = unitOfwork;
        }

        public ResponseCreateTaskJson Execute(RequestCreateTaskJson request)
        {
            Validate(request);

            var myTask = new MyTask
            {
                Name = request.Name,
                Description = request.Description,
                TaskPriority = (Data.Enums.TaskPriority)request.TaskPriority,
                TimeToEnd = request.TimeToEnd,
                Status = (Data.Enums.TaskStatus)request.Status,
            };

            _taskRepository.Add(myTask);
            _unitOfwork.Commit();

            return new ResponseCreateTaskJson();
        }

        private void Validate(RequestCreateTaskJson request)
        {
            var validator = new CreateTaskValidator();
            var result = validator.Validate(request);
            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
