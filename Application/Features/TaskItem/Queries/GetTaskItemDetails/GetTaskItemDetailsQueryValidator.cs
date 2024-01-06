using FluentValidation;

namespace Application.Features.TaskItem.Queries.GetTaskItemDetails
{
    public class GetTaskItemDetailsQueryValidator : AbstractValidator<GetTaskItemDetailsQuery>
    {
        public GetTaskItemDetailsQueryValidator()
        {
            RuleFor(ti => ti.Id)
                .NotNull().WithMessage("{ProperyName} ID can not be empty.")
                .NotEmpty().WithMessage("Invalid {ProperyName} ID.");
        }
    }
}
