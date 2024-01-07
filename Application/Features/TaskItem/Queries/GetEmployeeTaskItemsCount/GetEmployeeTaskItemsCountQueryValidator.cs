using FluentValidation;

namespace Application.Features.TaskItem.Queries.GetEmployeeTaskItemsCount
{
    public class GetEmployeeTaskItemsCountQueryValidator : AbstractValidator<GetEmployeeTaskItemsCountQuery>
    {
        public GetEmployeeTaskItemsCountQueryValidator()
        {
            RuleFor(ti => ti.EmployeeId)
                .NotNull().WithMessage("{PropertyName} can not be null.")
                .NotEmpty().WithMessage("{PropertyName} can not be empty.");
        }
    }
}
