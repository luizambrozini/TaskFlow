using FluentValidation;
using TaskFlow.Comunication.Requests;

namespace TaskFlow.Application.UseCases.Tasks.UpdateTask
{
    internal class UpdateTaskValidator : AbstractValidator<RequestUpdateTaskJson>
    {
        public UpdateTaskValidator()
        {
            RuleFor(t => t.Id).GreaterThan(0).WithMessage("Task id must be greater than 0");
        }
    }
}
