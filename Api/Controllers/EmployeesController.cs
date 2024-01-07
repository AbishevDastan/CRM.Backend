using Application.Features.Employee.Commands.CreateEmployee;
using Application.Features.Employee.Commands.DeleteEmployee;
using Application.Features.Employee.Commands.UpdateEmployee;
using Application.Features.Employee.Queries.GetAllEmployees;
using Application.Features.Employee.Queries.GetEmployeeDetails;
using Application.Features.Employee.Queries.SearchEmployees;
using Application.Features.Employee.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<EmployeeDto>> Get()
        {
            return await _mediator.Send(new GetEmployeesQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> Get(int id)
        {
            var employee = await _mediator.Send(new GetEmployeeDetailsQuery(id));
            return Ok(employee);
        }

        [HttpGet("search")]
        public async Task<ActionResult<List<EmployeeDto>>> Get(string searchText)
        {
            var searchResult = await _mediator.Send(new SearchEmployeesQuery(searchText));
            return Ok(searchResult);
        }


        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> Post(CreateEmployeeCommand employee)
        {
            var response = await _mediator.Send(employee);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateEmployeeCommand employee)
        {
            await _mediator.Send(employee);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteEmployeeCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
