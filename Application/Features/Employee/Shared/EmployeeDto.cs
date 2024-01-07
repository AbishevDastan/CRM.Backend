namespace Application.Features.Employee.Shared
{
    public abstract class EmployeeDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
    }
}
