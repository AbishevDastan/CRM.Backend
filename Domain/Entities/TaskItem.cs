using System;

namespace Domain.Entities
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset DeadLine { get; set; }
        public int CompletionPercentage { get; set; }

        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
    }
}
