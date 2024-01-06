using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using MediatR;

namespace Application.Features.TaskItem.Commands.CreateTaskItem
{
    public class CreateTaskItemCommandHandler : IRequestHandler<CreateTaskItemCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ITaskItemRepository _taskItemRepository;

        public CreateTaskItemCommandHandler(IMapper mapper,
            ITaskItemRepository taskItemRepository)
        {
            _mapper = mapper;
            _taskItemRepository = taskItemRepository;
        }

        public async Task<int> Handle(CreateTaskItemCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateTaskItemCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid task item data", validationResult);

            var taskItemToCreate = _mapper.Map<Domain.TaskItem>(request);

            await _taskItemRepository.Create(taskItemToCreate);

            return taskItemToCreate.Id;
        }
    }
}
