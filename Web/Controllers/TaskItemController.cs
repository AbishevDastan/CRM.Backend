using Application.Services.TaskItemService;
using Application.UseCases.Employee;
using Application.UseCases.TaskItem;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskItemController : ControllerBase
    {
        private readonly ITaskItemService _taskItemService;

        public TaskItemController(ITaskItemService taskItemService)
        {
            _taskItemService = taskItemService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskItemDto>>> GetTaskItems()
        {
            var taskItems = await _taskItemService.GetTaskItems();

            if (taskItems == null)
                return NotFound();

            return Ok(taskItems);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItemDto>> GetTaskItem(int id)
        {
            var taskItem = await _taskItemService.GetTaskItem(id);

            if (taskItem == null)
                return NotFound();

            return Ok(taskItem);
        }

        [HttpGet("{employeeId}/tasks-by-employee-id")]
        public async Task<ActionResult<List<TaskItemDto>>> GetTaskItemsByEmployeeId(int employeeId)
        {
            var taskItems = await _taskItemService.GetTaskItemsByEmployeeId(employeeId);

            if (taskItems == null)
                return NotFound();

            return Ok(taskItems);
        }

        [HttpGet("{employeeId}/count")]
        public async Task<ActionResult<int>> GetEmployeeTasksCount(int employeeId)
        {
            var employeeTaskItemsCount = await _taskItemService.GetEmployeeTasksCount(employeeId);

            if (employeeTaskItemsCount <= 0)
                return NotFound();

            return Ok(employeeTaskItemsCount);
        }

        [HttpPost]
        public async Task<ActionResult<TaskItemDto>> AddTaskItem(TaskItemDto taskItemDto)
        {
            var result = await _taskItemService.AddTaskItem(taskItemDto);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<TaskItemDto>> UpdateTaskItem(TaskItemDto taskItemDto)
        {
            var result = await _taskItemService.UpdateTaskItem(taskItemDto);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteTaskItem(int id)
        {
            var result = await _taskItemService.DeleteTaskItem(id);

            if (result != true)
                return NotFound();

            return Ok(result);
        }
    }
}
