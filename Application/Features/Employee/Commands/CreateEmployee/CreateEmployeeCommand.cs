using MediatR;

namespace Application.Features.Employee.Commands.CreateEmployee
{
    public class CreateEmployeeCommand : IRequest<int>
    {
        public string FullName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
    }
}
