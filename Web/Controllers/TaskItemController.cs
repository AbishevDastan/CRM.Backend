using Application.Services.TaskItemService;
using Application.UseCases.Employee;
using Application.UseCases.TaskItem;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public async Task<ActionResult<List<TaskItemDto>>> GetTaskItems()
        {
            var taskItems = await _taskItemService.GetTaskItems();

            if (taskItems == null)
                return NotFound();

            return Ok(taskItems);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<TaskItemDto>> GetTaskItem(int id)
        {
            var taskItem = await _taskItemService.GetTaskItem(id);

            if (taskItem == null)
                return NotFound();

            return Ok(taskItem);
        }

        [HttpGet("{employeeId}/task-items-by-employee-id")]
        [Authorize]
        public async Task<ActionResult<List<TaskItemDto>>> GetTaskItemsByEmployeeId(int employeeId)
        {
            var taskItems = await _taskItemService.GetTaskItemsByEmployeeId(employeeId);

            if (taskItems == null)
                return NotFound();

            return Ok(taskItems);
        }

        [HttpGet("/overdue-task-items")]
        [Authorize]
        public async Task<ActionResult<List<TaskItemDto>>> GetOverdueTaskItems()
        {
            var overdueTaskItems = await _taskItemService.GetOverdueTaskItems();

            if (overdueTaskItems == null)
                return NotFound();

            return Ok(overdueTaskItems);
        }

        [HttpGet("{employeeId}/count")]
        [Authorize]
        public async Task<ActionResult<int>> GetEmployeeTasksCount(int employeeId)
        {
            var employeeTaskItemsCount = await _taskItemService.GetEmployeeTasksCount(employeeId);

            if (employeeTaskItemsCount <= 0)
                return NotFound();

            return Ok(employeeTaskItemsCount);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<TaskItemDto>> AddTaskItem(AddTaskItemDto addTaskItemDto)
        {
            var result = await _taskItemService.AddTaskItem(addTaskItemDto);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<TaskItemDto>> UpdateTaskItem(UpdateTaskItemDto updateTaskItemDto, int id)
        {
            var result = await _taskItemService.UpdateTaskItem(updateTaskItemDto, id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<bool>> DeleteTaskItem(int id)
        {
            var result = await _taskItemService.DeleteTaskItem(id);

            if (result != true)
                return NotFound();

            return Ok(result);
        }
    }
}
