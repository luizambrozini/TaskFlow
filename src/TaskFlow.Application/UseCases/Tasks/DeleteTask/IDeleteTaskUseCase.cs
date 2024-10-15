using TaskFlow.Comunication.Requests;

namespace TaskFlow.Application.UseCases.Tasks.DeleteTask
{
    public interface IDeleteTaskUseCase
    {
        bool Execute(RequestDeleteTaskJson request);
    }
}
