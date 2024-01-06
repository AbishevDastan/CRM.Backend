using FluentValidation;

namespace Application.Features.Employee.Commands.CreateEmployee
{
    public class CreateEmployeeCommandValidator
        : AbstractValidator<CreateEmployeeCommand>
    {
        //private readonly IEmployeeRepository _employeeRepository;

        public CreateEmployeeCommandValidator()
        {
            RuleFor(e => e.FullName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters.");

            RuleFor(e => e.Position)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters.");

            //RuleFor(e => e)
            //    .MustAsync(EmployeeNameUnique)
            //    .WithMessage("Employee already exists");

            //_employeeRepository = employeeRepository;
        }

        //private Task<bool> EmployeeNameUnique(CreateEmployeeCommand command, CancellationToken token)
        //{
        //    return _employeeRepository.IsEmployeeUnique(command.);
        //}
    }
}
