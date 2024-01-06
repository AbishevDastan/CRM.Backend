namespace Application.Features.Employee.Queries.GetEmployeeDetails
{
    public class EmployeeDetailsDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
    }
}
