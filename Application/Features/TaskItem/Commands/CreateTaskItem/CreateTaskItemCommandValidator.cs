using FluentValidation;

namespace Application.Features.TaskItem.Commands.CreateTaskItem
{
    public class CreateTaskItemCommandValidator : AbstractValidator<CreateTaskItemCommand>
    {
        public CreateTaskItemCommandValidator()
        {
            RuleFor(ti => ti.EmployeeId)
                .NotEmpty().WithMessage("{PropertyName} can not be empty.")
                .NotNull().WithMessage("{PropertyName} can not be null.");

            RuleFor(e => e.Content)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must be fewer than 500 characters.");

            RuleFor(e => e.Deadline)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .Must(BeAValidDate).WithMessage("Deadline date must be valid");
        }

        private bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }
    }
}
