using FluentValidation;
using TaskFlow.Comunication.Requests;

namespace TaskFlow.Application.UseCases.Tasks.CreateTask
{
    internal class CreateTaskValidator : AbstractValidator<RequestCreateTaskJson>
    {
        public CreateTaskValidator()
        {
            RuleFor(t => t.Name).NotEmpty().WithMessage("The name of task is required.");
            RuleFor(t => t.TaskPriority).IsInEnum().WithMessage("The priority is invalid.");
            RuleFor(t => t.TimeToEnd).LessThanOrEqualTo(DateTime.UtcNow).WithMessage("The time to end cannot be in the past.");
            RuleFor(t => t.Status).IsInEnum().WithMessage("The status is invalid.");
        }
    }
}
