using Application.Features.TaskItem.Shared;
using MediatR;

namespace Application.Features.TaskItem.Queries.GetTaskItemsByEmployeeId
{
    public record GetTaskItemsByEmployeeIdQuery(int EmployeeId) : IRequest<List<TaskItemDto>>;
}
