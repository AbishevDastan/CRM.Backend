using Application.UseCases.Employee;
using Application.UseCases.TaskItem;
using AutoMapper;
using Domain.Abstractions;
using Domain.Entities;

namespace Application.Services.TaskItemService
{
    public class TaskItemService : ITaskItemService
    {
        private readonly ITaskItemRepository _taskItemRepository;
        private readonly IMapper _mapper;

        public TaskItemService(ITaskItemRepository taskItemRepository, IMapper mapper)
        {
            _taskItemRepository = taskItemRepository;
            _mapper = mapper;
        }

        public async Task<TaskItemDto> GetTaskItem(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid task ID.", nameof(id));

            var taskItem = await _taskItemRepository.GetTaskItem(id);

            if (taskItem == null)
                throw new InvalidOperationException($"Task with ID {id} not found.");

            return _mapper.Map<TaskItemDto>(taskItem);
        }

        public async Task<List<TaskItemDto>> GetTaskItems()
        {
            var taskItems = await _taskItemRepository.GetTaskItems();

            if (taskItems == null || taskItems.Count <= 0)
                throw new InvalidOperationException("Tasks not found.");

            return _mapper.Map<List<TaskItemDto>>(taskItems);
        }

        public async Task<List<TaskItemDto>> GetTaskItemsByEmployeeId(int employeeId)
        {
            var taskItems = await _taskItemRepository.GetTaskItemsByEmployeeId(employeeId);

            if (taskItems == null || taskItems.Count <= 0)
                throw new InvalidOperationException("Tasks not found.");

            return _mapper.Map<List<TaskItemDto>>(taskItems);
        }

        public async Task<List<TaskItemDto>> GetOverdueTaskItems()
        {
            var overdueTaskItems = await _taskItemRepository.GetOverdueTaskItems();

            if(overdueTaskItems == null || overdueTaskItems.Count <= 0) 
                throw new InvalidOperationException("Просроченных заданий нет.");

            return _mapper.Map<List<TaskItemDto>>(overdueTaskItems);
        }

        public async Task<int> GetEmployeeTasksCount(int employeeId)
        {
            return await _taskItemRepository.GetEmployeeTasksCount(employeeId);
        }

        public async Task<TaskItemDto> AddTaskItem(AddTaskItemDto addTaskItemDto)
        {
            if (addTaskItemDto == null)
                throw new ArgumentNullException(nameof(addTaskItemDto), "Task cannot be null.");

            if (string.IsNullOrWhiteSpace(addTaskItemDto.Title))
                throw new ArgumentException("Task's title cannot be empty or null.", nameof(addTaskItemDto.Title));
            if (string.IsNullOrWhiteSpace(addTaskItemDto.Description))
                throw new ArgumentException("Task's description cannot be empty or null.", nameof(addTaskItemDto.Description));

            var addedTaskItem = await _taskItemRepository.AddTaskItem(_mapper.Map<TaskItem>(addTaskItemDto));

            return _mapper.Map<TaskItemDto>(addedTaskItem);
        }

        public async Task<bool> DeleteTaskItem(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid task ID.", nameof(id));

            await _taskItemRepository.DeleteTaskItem(id);
            return true;
        }

        public async Task<TaskItemDto> UpdateTaskItem(UpdateTaskItemDto updateTaskItemDto, int id)
        {
            if (updateTaskItemDto == null)
                throw new ArgumentNullException(nameof(updateTaskItemDto), "Task cannot be null.");

            if (string.IsNullOrWhiteSpace(updateTaskItemDto.Title))
                throw new ArgumentException("Task's title cannot be empty or null.", nameof(updateTaskItemDto.Title));
            if (string.IsNullOrWhiteSpace(updateTaskItemDto.Description))
                throw new ArgumentException("Task's description cannot be empty or null.", nameof(updateTaskItemDto.Description));

            var updatedTaskItem = await _taskItemRepository.UpdateTaskItem(_mapper.Map<TaskItem>(updateTaskItemDto), id);

            return _mapper.Map<TaskItemDto>(updatedTaskItem);
        }
    }
}
