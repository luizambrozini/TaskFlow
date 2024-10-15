using TaskFlow.Comunication.Requests;
using TaskFlow.Comunication.Responses;

namespace TaskFlow.Application.UseCases.Tasks.GetTask
{
    public interface IGetMyTaskByIdUseCase
    {
        ResponseMyTaskJson Execute(RequestMyTaskByIdJson request);
    }
}
