using FluentValidation;

namespace Application.Features.Employee.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommandValidator : AbstractValidator<DeleteEmployeeCommand>
    {
        public DeleteEmployeeCommandValidator()
        {
            RuleFor(e => e.Id)
                .NotNull().WithMessage("{ProperyName} ID can not be empty.")
                .NotEmpty().WithMessage("Invalid {ProperyName} ID.");
        }
    }
}
