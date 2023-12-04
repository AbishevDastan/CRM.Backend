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

        public async Task<int> GetEmployeeTasksCount(int employeeId)
        {
            return await _taskItemRepository.GetEmployeeTasksCount(employeeId);
        }

        public async Task<TaskItemDto> AddTaskItem(TaskItemDto taskItemDto)
        {
            if (taskItemDto == null)
                throw new ArgumentNullException(nameof(taskItemDto), "Task cannot be null.");

            if (string.IsNullOrWhiteSpace(taskItemDto.Title))
                throw new ArgumentException("Task's title cannot be empty or null.", nameof(taskItemDto.Title));
            if (string.IsNullOrWhiteSpace(taskItemDto.Description))
                throw new ArgumentException("Task's description cannot be empty or null.", nameof(taskItemDto.Description));

            var addedTaskItem = await _taskItemRepository.AddTaskItem(_mapper.Map<TaskItem>(taskItemDto));

            return _mapper.Map<TaskItemDto>(addedTaskItem);
        }

        public async Task<bool> DeleteTaskItem(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid task ID.", nameof(id));

            await _taskItemRepository.DeleteTaskItem(id);
            return true;
        }

        public async Task<TaskItemDto> UpdateTaskItem(TaskItemDto taskItemDto)
        {
            if (taskItemDto == null)
                throw new ArgumentNullException(nameof(taskItemDto), "Task cannot be null.");

            if (string.IsNullOrWhiteSpace(taskItemDto.Title))
                throw new ArgumentException("Task's title cannot be empty or null.", nameof(taskItemDto.Title));
            if (string.IsNullOrWhiteSpace(taskItemDto.Description))
                throw new ArgumentException("Task's description cannot be empty or null.", nameof(taskItemDto.Description));

            var updatedTaskItem = await _taskItemRepository.UpdateTaskItem(_mapper.Map<TaskItem>(taskItemDto));

            return _mapper.Map<TaskItemDto>(updatedTaskItem);
        }
    }
}
