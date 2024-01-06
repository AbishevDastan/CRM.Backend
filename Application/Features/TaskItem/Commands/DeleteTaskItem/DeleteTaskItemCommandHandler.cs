using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using MediatR;

namespace Application.Features.TaskItem.Commands.DeleteTaskItem
{
    public class DeleteTaskItemCommandHandler : IRequestHandler<DeleteTaskItemCommand, Unit>
    {
        private readonly ITaskItemRepository _taskItemRepository;

        public DeleteTaskItemCommandHandler(ITaskItemRepository taskItemRepository)
        {
            _taskItemRepository = taskItemRepository;
        }

        public async Task<Unit> Handle(DeleteTaskItemCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteTaskItemCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid task item", validationResult);

            var taskItemToDelete = await _taskItemRepository.GetById(request.Id);

            if (taskItemToDelete == null)
                throw new NotFoundException(nameof(TaskItem), request.Id);

            await _taskItemRepository.Delete(taskItemToDelete);

            return Unit.Value;
        }
    }
}
