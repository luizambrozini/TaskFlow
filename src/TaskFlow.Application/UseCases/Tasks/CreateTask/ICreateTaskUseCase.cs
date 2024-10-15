using TaskFlow.Comunication.Requests;
using TaskFlow.Comunication.Responses;

namespace TaskFlow.Application.UseCases.Tasks.CreateTask
{
    public interface ICreateTaskUseCase
    {
        ResponseCreateTaskJson Execute(RequestCreateTaskJson request);
    }
}
