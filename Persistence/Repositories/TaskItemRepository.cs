using Application.Contracts.Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;
using Persistence.Repositories.Common;

namespace Infrastructure.Repositories
{
    public class TaskItemRepository : GenericRepository<TaskItem>, ITaskItemRepository
    {
        public TaskItemRepository(CrmDatabaseContext context) : base(context)
        {
        }

        public async Task<List<TaskItem>> GetTaskItemsByEmployeeId(int employeeId)
        {
            return await _context.TaskItems
                .Where(ti => ti.EmployeeId == employeeId)
                .ToListAsync();
        }

        public async Task<int> GetEmployeeTaskItemsCount(int employeeId)
        {
            var employeeTaskItems = await GetTaskItemsByEmployeeId(employeeId);

            return employeeTaskItems.Count();
        }
    }
}
