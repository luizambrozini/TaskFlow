using FluentValidation;
using TaskFlow.Comunication.Requests;

namespace TaskFlow.Application.UseCases.Tasks.DeleteTask
{
    internal class DeleteTaskValidator : AbstractValidator<RequestDeleteTaskJson>
    {
        public DeleteTaskValidator()
        {
            RuleFor(t => t.Id).GreaterThan(0).WithMessage("Task id must be greater than 0");
        }
    }
}
