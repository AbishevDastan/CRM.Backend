namespace Application.Features.TaskItem.Shared
{
    public class TaskItemDto
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; }
        public DateTime Deadline { get; set; }
        public int EmployeeId { get; set; }
    }
}
