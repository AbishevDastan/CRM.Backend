using Application.Contracts.Persistence;
using Application.Features.TaskItem.Commands.UpdateTaskItem;
using FluentValidation;

namespace Application.Features.Employee.Commands.UpdateEmployee
{
    public class UpdateTaskItemCommandValidator : AbstractValidator<UpdateTaskItemCommand>
    {
        private readonly ITaskItemRepository _taskItemRepository;

        public UpdateTaskItemCommandValidator(ITaskItemRepository taskItemRepository)
        {
            RuleFor(e => e.Id)
                .NotNull()
                .MustAsync(TaskItemMustExist);

            RuleFor(e => e.Content)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must be fewer than 500 characters.");

            RuleFor(e => e.Deadline)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .Must(BeAValidDate).WithMessage("Deadline date must be valid");

            _taskItemRepository = taskItemRepository;
        }

        private bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }

        private async Task<bool> TaskItemMustExist(int id, CancellationToken arg2)
        {
            var taskItem = await _taskItemRepository.GetById(id);

            return taskItem != null;
        }
    }
}
