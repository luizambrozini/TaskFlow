using TaskFlow.Comunication.Requests;

namespace TaskFlow.Application.UseCases.Tasks.UpdateTask
{
    public interface IUpdateTaskUseCase
    {
        void Execute(RequestUpdateTaskJson request);
    }
}
