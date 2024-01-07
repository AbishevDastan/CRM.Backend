using Application.Features.TaskItem.Shared;
using MediatR;

namespace Application.Features.TaskItem.Queries.GetTaskItemDetails
{
    public record GetTaskItemDetailsQuery(int Id) : IRequest<TaskItemDto>
    {
    }
}
