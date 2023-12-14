using Domain.Entities;

namespace Domain.Abstractions
{
    public interface ITaskItemRepository
    {
        Task<TaskItem> GetTaskItem(int id);
        Task<List<TaskItem>> GetTaskItems();
        Task<List<TaskItem>> GetTaskItemsByEmployeeId(int employeeId);
        Task<List<TaskItem>> GetOverdueTaskItems();
        Task<int> GetEmployeeTasksCount(int employeeId);
        Task<TaskItem> AddTaskItem(TaskItem taskItem);
        Task<TaskItem> UpdateTaskItem(TaskItem taskItem, int id);
        Task DeleteTaskItem(int id);
    }
}
