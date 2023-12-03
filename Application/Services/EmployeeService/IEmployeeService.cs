using Application.UseCases.Employee;
using Domain.Entities;

namespace Application.Services.EmployeeService
{
    public interface IEmployeeService
    {
        Task<EmployeeDto> GetEmployee(int id);
        Task<List<EmployeeDto>> GetEmployees();
        Task<List<EmployeeDto>> SearchEmployees(string searchText);
        Task<EmployeeDto> AddEmployee(EmployeeDto employeeDto);
        Task<EmployeeDto> UpdateEmployee(EmployeeDto employeeDto);
        Task<bool> DeleteEmployee(int id);
    }
}
