using Application.Features.Employee.Shared;
using MediatR;

namespace Application.Features.Employee.Queries.SearchEmployees
{
    public record SearchEmployeesQuery(string SearchText) : IRequest<List<EmployeeDto>>;
}
