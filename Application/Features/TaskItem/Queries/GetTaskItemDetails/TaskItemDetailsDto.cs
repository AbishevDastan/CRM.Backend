namespace Application.Features.TaskItem.Queries.GetTaskItemDetails
{
    public class TaskItemDetailsDto
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset Deadline { get; set; }
        public int EmployeeId { get; set; }
    }
}
