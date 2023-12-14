using Application.Services.EmployeeService;
using Application.UseCases.Employee;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("employees")]
        [Authorize]
        public async Task<ActionResult<List<EmployeeDto>>> GetEmployees()
        {
            var employees = await _employeeService.GetEmployees();

            if (employees == null)
                return NotFound();

            return Ok(employees);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<EmployeeDto>> GetEmployee(int id)
        {
            var employee = await _employeeService.GetEmployee(id);

            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        [HttpGet("{searchText}/search")]
        [Authorize]
        public async Task<ActionResult<List<EmployeeDto>>> SearchEmployees(string searchText)
        {
            var result = await _employeeService.SearchEmployees(searchText);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<EmployeeDto>> AddEmployee(AddEmployeeDto addEmployeeDto)
        {
            var result = await _employeeService.AddEmployee(addEmployeeDto);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<EmployeeDto>> UpdateEmployee(UpdateEmployeeDto updateEmployeeDto, int id)
        {
            var result = await _employeeService.UpdateEmployee(updateEmployeeDto, id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<bool>> DeleteEmployee(int id)
        {
            var result = await _employeeService.DeleteEmployee(id);

            if (result != true)
                return NotFound();

            return Ok(result);
        }
    }
}
