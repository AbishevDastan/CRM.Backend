using MediatR;

namespace Application.Features.TaskItem.Queries.GetEmployeeTaskItemsCount
{
    public record GetEmployeeTaskItemsCountQuery(int EmployeeId) : IRequest<int>;
}
