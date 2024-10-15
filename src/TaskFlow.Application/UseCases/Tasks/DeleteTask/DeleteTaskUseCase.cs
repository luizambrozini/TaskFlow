using TaskFlow.Data.Repositories.Tasks;
using TaskFlow.Data.Repositories;
using TaskFlow.Comunication.Requests;
using TaskFlow.Application.Exceptions.ExceptionsBase;

namespace TaskFlow.Application.UseCases.Tasks.DeleteTask
{
    internal class DeleteTaskUseCase : IDeleteTaskUseCase
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IUnitOfwork _unitOfwork;

        public DeleteTaskUseCase(ITaskRepository taskRepository, IUnitOfwork unitOfwork)
        {
            _taskRepository = taskRepository;
            _unitOfwork = unitOfwork;
        }

        public bool Execute(RequestDeleteTaskJson request)
        {
            Validate(request);

            var myTask = _taskRepository.Get(request.Id);

            if (myTask == null)
            {
                var errorMessage = "The task are not found by id informed";
                throw new ErrorOnNotFoundException(errorMessage);
            }

            try
            {
                _taskRepository.Delete(myTask.Id);
                _unitOfwork.Commit();
            }
            catch
            {
                var errorMessage = "The task are not found by id informed";
                throw new ErrorOnDeleteException(errorMessage);
            }

            return true;

        }

        private void Validate(RequestDeleteTaskJson request)
        {
            var validator = new DeleteTaskValidator();
            var result = validator.Validate(request);
            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
