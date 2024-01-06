using MediatR;

namespace Application.Features.TaskItem.Commands.UpdateTaskItem
{
    public class UpdateTaskItemCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime Deadline { get; set; }
        public int EmployeeId { get; set; }
    }
}
