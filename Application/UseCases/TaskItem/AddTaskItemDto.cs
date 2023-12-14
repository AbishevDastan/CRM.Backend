namespace Application.UseCases.TaskItem
{
    public class AddTaskItemDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset DeadLine { get; set; }
        public int CompletionPercentage { get; set; }
        public int EmployeeId { get; set; }
    }
}
