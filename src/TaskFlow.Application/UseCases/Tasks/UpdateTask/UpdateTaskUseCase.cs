using TaskFlow.Data.Repositories.Tasks;
using TaskFlow.Data.Repositories;
using TaskFlow.Comunication.Requests;
using TaskFlow.Application.Exceptions.ExceptionsBase;

namespace TaskFlow.Application.UseCases.Tasks.UpdateTask
{
    internal class UpdateTaskUseCase : IUpdateTaskUseCase
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IUnitOfwork _unitOfwork;

        public UpdateTaskUseCase(ITaskRepository taskRepository, IUnitOfwork unitOfwork)
        {
            _taskRepository = taskRepository;
            _unitOfwork = unitOfwork;
        }

        public void Execute(RequestUpdateTaskJson request)
        {
            Validate(request);

            var myTask = _taskRepository.Get(request.Id);

            if (myTask == null)
            {
                var errorMessage = "The task are not found by id informed";
                throw new ErrorOnNotFoundException(errorMessage);
            }

            if (request.Name != null) myTask.Name = request.Name;
            if (request.Description != null) myTask.Description = request.Description;
            if (request.TaskPriority != null) myTask.TaskPriority = (Data.Enums.TaskPriority)request.TaskPriority;
            if (request.TimeToEnd != null) myTask.TimeToEnd = (DateTime)request.TimeToEnd;
            if (request.Status != null) myTask.Status = (Data.Enums.TaskStatus)request.Status;

            _taskRepository.Update(myTask);
            _unitOfwork.Commit();

        }

        private void Validate(RequestUpdateTaskJson request)
        {
            var validator = new UpdateTaskValidator();
            var result = validator.Validate(request);
            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
