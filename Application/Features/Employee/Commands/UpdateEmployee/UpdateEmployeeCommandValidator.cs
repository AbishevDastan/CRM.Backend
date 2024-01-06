using Application.Contracts.Persistence;
using FluentValidation;

namespace Application.Features.Employee.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public UpdateEmployeeCommandValidator(IEmployeeRepository employeeRepository)
        {
            RuleFor(e => e.Id)
                .NotNull()
                .MustAsync(EmployeeMustExist);

            RuleFor(e => e.FullName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters.");

            RuleFor(e => e.Position)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters.");

            _employeeRepository = employeeRepository;
        }

        private async Task<bool> EmployeeMustExist(int id, CancellationToken arg2)
        {
            var employee = await _employeeRepository.GetById(id);

            return employee != null;
        }
    }
}
