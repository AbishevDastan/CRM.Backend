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
        Task<TaskItemDto> AddTaskItem(AddTaskItemDto updateTaskItemDto);
        Task<TaskItemDto> UpdateTaskItem(UpdateTaskItemDto addTaskItemDto, int id);
        Task<bool> DeleteTaskItem(int id);
    }
}
