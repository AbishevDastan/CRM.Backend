using Application.Contracts.Persistence.Common;
using Domain;

namespace Application.Contracts.Persistence
{
    public interface ITaskItemRepository : IGenericRepository<TaskItem>
    {
        Task<List<TaskItem>> GetTaskItemsByEmployeeId(int employeeId);
        Task<int> GetEmployeeTaskItemsCount(int employeeId);
    }
}
