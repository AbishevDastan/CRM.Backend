using Application.Contracts.Persistence;
using Application.Features.TaskItem.Shared;
using AutoMapper;
using MediatR;

namespace Application.Features.TaskItem.Queries.GetTaskItemsByEmployeeId
{
    public class GetTaskItemsByEmployeeIdQueryHandler : IRequestHandler<GetTaskItemsByEmployeeIdQuery, List<TaskItemDto>>
    {
        private readonly IMapper _mapper;
        private readonly ITaskItemRepository _taskItemRepository;

        public GetTaskItemsByEmployeeIdQueryHandler(IMapper mapper,
            ITaskItemRepository taskItemRepository)
        {
            _mapper = mapper;
            _taskItemRepository = taskItemRepository;
        }

        public async Task<List<TaskItemDto>> Handle(GetTaskItemsByEmployeeIdQuery request, CancellationToken cancellationToken)
        {
            var taskItems = await _taskItemRepository.GetTaskItemsByEmployeeId(request.EmployeeId);

            return _mapper.Map<List<TaskItemDto>>(taskItems);
        }
    }
}
