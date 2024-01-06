using MediatR;

namespace Application.Features.TaskItem.Commands.DeleteTaskItem
{
    public class DeleteTaskItemCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
