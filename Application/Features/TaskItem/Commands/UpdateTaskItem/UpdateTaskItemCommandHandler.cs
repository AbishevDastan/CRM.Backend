using Application.Contracts.Logging;
using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.TaskItem.Commands.UpdateTaskItem;
using AutoMapper;
using MediatR;

namespace Application.Features.Employee.Commands.UpdateEmployee
{
    public class UpdateTaskItemCommandHandler : IRequestHandler<UpdateTaskItemCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ITaskItemRepository _taskItemRepository;
        private readonly IAppLogger<UpdateTaskItemCommandHandler> _logger;

        public UpdateTaskItemCommandHandler(IMapper mapper,
            ITaskItemRepository taskItemRepository,
            IAppLogger<UpdateTaskItemCommandHandler> logger)
        {
            _mapper = mapper;
            _taskItemRepository = taskItemRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateTaskItemCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateTaskItemCommandValidator(_taskItemRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(TaskItem), request.Id);
                throw new BadRequestException("Invalid task item data", validationResult);
            }

            var taskItemToUpdate = _mapper.Map<Domain.TaskItem>(request);

            await _taskItemRepository.Update(taskItemToUpdate);

            return Unit.Value;
        }
    }
}
