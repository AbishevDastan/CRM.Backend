using FluentValidation;

namespace Application.Features.TaskItem.Commands.DeleteTaskItem
{
    public class DeleteTaskItemCommandValidator : AbstractValidator<DeleteTaskItemCommand>
    {
        public DeleteTaskItemCommandValidator()
        {
            RuleFor(ti => ti.Id)
                .NotNull().WithMessage("{ProperyName} ID can not be empty.")
                .NotEmpty().WithMessage("Invalid {ProperyName} ID.");
        }
    }
}
