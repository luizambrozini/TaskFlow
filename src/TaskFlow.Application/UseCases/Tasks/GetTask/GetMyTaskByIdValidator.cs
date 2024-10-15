using FluentValidation;
using TaskFlow.Comunication.Requests;

namespace TaskFlow.Application.UseCases.Tasks.GetTask
{
    internal class GetMyTaskByIdValidator : AbstractValidator<RequestMyTaskByIdJson>
    {
        public GetMyTaskByIdValidator()
        {
            RuleFor(r => r.TaskId).GreaterThan(0).WithMessage("Task id must be greater than 0");
        }
    }
}
