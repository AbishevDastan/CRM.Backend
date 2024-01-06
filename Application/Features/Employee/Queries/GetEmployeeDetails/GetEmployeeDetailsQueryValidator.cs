using FluentValidation;

namespace Application.Features.Employee.Queries.GetEmployeeDetails
{
    public class GetEmployeeDetailsQueryValidator : AbstractValidator<GetEmployeeDetailsQuery>
    {
        public GetEmployeeDetailsQueryValidator()
        {
            RuleFor(e => e.Id)
                .NotNull().WithMessage("{ProperyName} ID can not be empty.")
                .NotEmpty().WithMessage("Invalid {ProperyName} ID.");
        }
    }
}
