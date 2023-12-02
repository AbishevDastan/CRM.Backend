using Application.UseCases.TaskItem;

namespace Application.Services.TaskItemService
{
    public interface ITaskItemService
    {
        Task<TaskItemDto> GetTaskItem(int id);
        Task<List<TaskItemDto>> GetTaskItems();
        Task<TaskItemDto> AddTaskItem(TaskItemDto taskItemDto);
        Task<TaskItemDto> UpdateTaskItem(TaskItemDto taskItemDto);
        Task<bool> DeleteTaskItem(int id);
    }
}
