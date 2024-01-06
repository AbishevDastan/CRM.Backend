using FluentValidation;

namespace Application.Features.Employee.Queries.SearchEmployees
{
    public class SearchEmployeesQueryValidator : AbstractValidator<SearchEmployeesQuery>
    {
        public SearchEmployeesQueryValidator()
        {
            RuleFor(e => e.SearchText)
                .MaximumLength(70).WithMessage("{PropertyName} can not be longer than 70 characters.");
        }
    }
}
