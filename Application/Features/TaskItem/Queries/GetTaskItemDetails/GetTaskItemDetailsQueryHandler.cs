using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.TaskItem.Shared;
using AutoMapper;
using MediatR;

namespace Application.Features.TaskItem.Queries.GetTaskItemDetails
{
    public class GetTaskItemDetailsQueryHandler : IRequestHandler<GetTaskItemDetailsQuery, TaskItemDto>
    {
        private readonly IMapper _mapper;
        private readonly ITaskItemRepository _taskItemRepository;

        public GetTaskItemDetailsQueryHandler(IMapper mapper,
            ITaskItemRepository taskItemRepository)
        {
            _mapper = mapper;
            _taskItemRepository = taskItemRepository;
        }

        public async Task<TaskItemDto> Handle(GetTaskItemDetailsQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetTaskItemDetailsQueryValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid task item", validationResult);

            var taskItem = await _taskItemRepository.GetById(request.Id);

            if (taskItem == null)
                throw new NotFoundException(nameof(Domain.TaskItem), request.Id);

            return _mapper.Map<TaskItemDto>(taskItem);
        }
    }
}
