using MediatR;

namespace Application.Features.TaskItem.Commands.CreateTaskItem
{
    public class CreateTaskItemCommand : IRequest<int>
    {
        public string Content { get; set; } = string.Empty;
        public DateTime Deadline { get; set; }
        public int EmployeeId { get; set; }
    }
}
