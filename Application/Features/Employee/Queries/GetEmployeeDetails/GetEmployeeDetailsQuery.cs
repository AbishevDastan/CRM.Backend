using MediatR;

namespace Application.Features.Employee.Queries.GetEmployeeDetails
{
    public record GetEmployeeDetailsQuery(int Id) : IRequest<EmployeeDetailsDto>;
}
