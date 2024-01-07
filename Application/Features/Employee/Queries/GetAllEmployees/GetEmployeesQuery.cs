using Application.Features.Employee.Shared;
using MediatR;

namespace Application.Features.Employee.Queries.GetAllEmployees
{
    public record GetEmployeesQuery : IRequest<List<EmployeeDto>>;
}
