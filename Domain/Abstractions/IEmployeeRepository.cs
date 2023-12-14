using Domain.Entities;

namespace Domain.Abstractions
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetEmployee(int id);
        Task<List<Employee>> GetEmployees();
        Task<List<Employee>> SearchEmployees(string searchText);
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee> UpdateEmployee(Employee employee, int id);
        Task DeleteEmployee(int id);
    }
}
