using Application.UseCases.TaskItem;
using Domain.Entities;

namespace Application.Services.TaskItemService
{
    public interface ITaskItemService
    {
        Task<TaskItemDto> GetTaskItem(int id);
        Task<List<TaskItemDto>> GetTaskItems();
        Task<List<TaskItemDto>> GetTaskItemsByEmployeeId(int employeeId);
        Task<List<TaskItemDto>> GetOverdueTaskItems();
        Task<int> GetEmployeeTasksCount(int employeeId);
        Task<TaskItemDto> AddTaskItem(TaskItemDto taskItemDto);
        Task<TaskItemDto> UpdateTaskItem(TaskItemDto taskItemDto);
        Task<bool> DeleteTaskItem(int id);
    }
}
