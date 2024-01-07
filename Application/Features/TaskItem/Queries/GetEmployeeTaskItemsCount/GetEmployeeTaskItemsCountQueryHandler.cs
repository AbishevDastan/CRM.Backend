using Application.Contracts.Persistence;
using Application.Exceptions;
using MediatR;

namespace Application.Features.TaskItem.Queries.GetEmployeeTaskItemsCount
{
    public class GetEmployeeTaskItemsCountQueryHandler : IRequestHandler<GetEmployeeTaskItemsCountQuery, int>
    {
        private readonly ITaskItemRepository _taskItemRepository;

        public GetEmployeeTaskItemsCountQueryHandler(ITaskItemRepository taskItemRepository)
        {
            _taskItemRepository = taskItemRepository;
        }

        public async Task<int> Handle(GetEmployeeTaskItemsCountQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetEmployeeTaskItemsCountQueryValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid employee ID.", validationResult);

            return await _taskItemRepository.GetEmployeeTaskItemsCount(request.EmployeeId);

        }
    }
}
