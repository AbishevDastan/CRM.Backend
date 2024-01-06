using Application.Contracts.Persistence.Common;
using Domain;

namespace Application.Contracts.Persistence
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<List<Employee>> SearchEmployees(string searchText);
    }
}
