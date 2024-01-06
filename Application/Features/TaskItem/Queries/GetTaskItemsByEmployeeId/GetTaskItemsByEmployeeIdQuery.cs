using Application.Features.TaskItem.Queries.GetAllTaskItems;
using MediatR;

namespace Application.Features.TaskItem.Queries.GetTaskItemsByEmployeeId
{
    public record GetTaskItemsByEmployeeIdQuery(int EmployeeId) : IRequest<List<TaskItemDto>>;
}
