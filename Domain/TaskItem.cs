using Domain.Common;

namespace Domain
{
    public class TaskItem : BaseEntity
    {
        public string Content { get; set; } = string.Empty;
        public DateTime Deadline { get; set; }

        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
    }
}
