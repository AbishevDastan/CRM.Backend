using Domain.Common;

namespace Domain
{
    public class Employee : BaseEntity
    {
        public string FullName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public List<TaskItem>? TaskItems { get; set; }
    }
}