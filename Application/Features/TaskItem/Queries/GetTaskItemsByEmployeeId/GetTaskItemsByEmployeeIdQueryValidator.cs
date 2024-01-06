using FluentValidation;

namespace Application.Features.TaskItem.Queries.GetTaskItemsByEmployeeId
{
    public class GetTaskItemsByEmployeeIdQueryValidator : AbstractValidator<GetTaskItemsByEmployeeIdQuery>
    {
        public GetTaskItemsByEmployeeIdQueryValidator()
        {
            RuleFor(ti => ti.EmployeeId)
                .NotNull().WithMessage("{PropertyName} can not be null.")
                .NotEmpty().WithMessage("{PropertyName} can not be empty.");
        }
    }
}
