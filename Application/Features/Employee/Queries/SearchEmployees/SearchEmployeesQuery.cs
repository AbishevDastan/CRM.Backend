using Application.Features.Employee.Queries.GetAllEmployees;
using MediatR;

namespace Application.Features.Employee.Queries.SearchEmployees
{
    public record SearchEmployeesQuery(string SearchText) : IRequest<List<EmployeeDto>>;
}
