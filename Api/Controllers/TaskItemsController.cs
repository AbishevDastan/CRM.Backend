﻿using Application.Features.TaskItem.Commands.CreateTaskItem;
using Application.Features.TaskItem.Commands.DeleteTaskItem;
using Application.Features.TaskItem.Commands.UpdateTaskItem;
using Application.Features.TaskItem.Queries.GetAllTaskItems;
using Application.Features.TaskItem.Queries.GetTaskItemDetails;
using Application.Features.TaskItem.Queries.GetTaskItemsByEmployeeId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskItemsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-all")]
        public async Task<List<TaskItemDto>> Get()
        {
            return await _mediator.Send(new GetTaskItemsQuery());
        }

        [HttpGet("{employeeId}/get-by-employee-id")]
        public async Task<List<TaskItemDto>> GetByEmployeeId(int employeeId)
        {
            return await _mediator.Send(new GetTaskItemsByEmployeeIdQuery(employeeId));
        }

        [HttpGet("{id}/get-by-id")]
        public async Task<ActionResult<TaskItemDetailsDto>> Get(int id)
        {
            var taskItem = await _mediator.Send(new GetTaskItemDetailsQuery(id));
            return Ok(taskItem);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> Post(CreateTaskItemCommand taskItem)
        {
            var response = await _mediator.Send(taskItem);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateTaskItemCommand taskItem)
        {
            await _mediator.Send(taskItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteTaskItemCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
