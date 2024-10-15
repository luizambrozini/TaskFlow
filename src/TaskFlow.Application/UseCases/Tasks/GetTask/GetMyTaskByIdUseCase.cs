using TaskFlow.Application.Exceptions.ExceptionsBase;
using TaskFlow.Comunication.Requests;
using TaskFlow.Comunication.Responses;
using TaskFlow.Data.Repositories;
using TaskFlow.Data.Repositories.Tasks;

namespace TaskFlow.Application.UseCases.Tasks.GetTask
{
    internal class GetMyTaskByIdUseCase : IGetMyTaskByIdUseCase
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IUnitOfwork _unitOfwork;

        public GetMyTaskByIdUseCase(ITaskRepository taskRepository, IUnitOfwork unitOfwork)
        {
            _taskRepository = taskRepository;
            _unitOfwork = unitOfwork;
        }

        public ResponseMyTaskJson Execute(RequestMyTaskByIdJson request)
        {
            Validate(request);

            var myTask = _taskRepository.Get(request.TaskId);
            if (myTask == null)
            {
                var errorMessage = "The task are not found by id informed";
                throw new ErrorOnNotFoundException(errorMessage);
            }

            return new ResponseMyTaskJson { MyTask = myTask };
        }

        private void Validate(RequestMyTaskByIdJson request)
        {
            var validator = new GetMyTaskByIdValidator();
            var result = validator.Validate(request);
            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
