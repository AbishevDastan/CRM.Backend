using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Features.TaskItem.Queries.GetAllTaskItems
{
    public class GetTaskItemsQueryHandler : IRequestHandler<GetTaskItemsQuery,
        List<TaskItemDto>>
    {
        private readonly IMapper _mapper;
        private readonly ITaskItemRepository _taskItemRepository;

        public GetTaskItemsQueryHandler(IMapper mapper,
            ITaskItemRepository taskItemRepository)
        {
            _mapper = mapper;
            _taskItemRepository = taskItemRepository;
        }

        public async Task<List<TaskItemDto>> Handle(GetTaskItemsQuery request, CancellationToken cancellationToken)
        {
            var taskItems = await _taskItemRepository.GetAll();

            return _mapper.Map<List<TaskItemDto>>(taskItems);
        }
    }
}
