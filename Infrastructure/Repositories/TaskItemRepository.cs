using Domain.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TaskItemRepository : ITaskItemRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TaskItemRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TaskItem> GetTaskItem(int id)
        {
            return await _dbContext.TaskItems.FirstOrDefaultAsync(ti => ti.Id == id);
        }

        public async Task<List<TaskItem>> GetTaskItems()
        {
            return await _dbContext.TaskItems.ToListAsync();
        }

        public async Task<TaskItem> AddTaskItem(TaskItem taskItem)
        {
            await _dbContext.AddAsync(taskItem);
            await _dbContext.SaveChangesAsync();
            return taskItem;
        }

        public async Task DeleteTaskItem(int id)
        {
            var taskItem = await GetTaskItem(id);

            _dbContext.TaskItems.Remove(taskItem);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<TaskItem> UpdateTaskItem(TaskItem taskItem)
        {
            var dbTaskItem = await GetTaskItem(taskItem.Id);

            if (dbTaskItem != null)
            {
                dbTaskItem.Title = taskItem.Title;
                dbTaskItem.Description = taskItem.Description;
                dbTaskItem.StartDate = taskItem.StartDate;
                dbTaskItem.DeadLine = taskItem.DeadLine;
                dbTaskItem.CompletionPercentage = taskItem.CompletionPercentage;
                dbTaskItem.EmployeeId = taskItem.EmployeeId;

                await _dbContext.SaveChangesAsync();
                return dbTaskItem;
            }

            throw new ArgumentNullException(nameof(taskItem));
        }
    }
}
