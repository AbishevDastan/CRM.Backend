using MediatR;

namespace Application.Features.TaskItem.Queries.GetAllTaskItems
{
    public record GetTaskItemsQuery : IRequest<List<TaskItemDto>>;
}
