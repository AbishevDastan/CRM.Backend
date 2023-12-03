using Application.UseCases.Employee;
using AutoMapper;
using Domain.Abstractions;
using Domain.Entities;

namespace Application.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<EmployeeDto> GetEmployee(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid employee ID.", nameof(id));

            var employee = await _employeeRepository.GetEmployee(id);

            if (employee == null)
                throw new InvalidOperationException($"Employee with ID {id} not found.");

            return _mapper.Map<EmployeeDto>(employee);
        }

        public async Task<List<EmployeeDto>> GetEmployees()
        {
            var employees = await _employeeRepository.GetEmployees();

            if (employees == null || employees.Count <= 0)
                throw new InvalidOperationException("Employees not found.");

            return _mapper.Map<List<EmployeeDto>>(employees);
        }

        public async Task<List<EmployeeDto>> SearchEmployees(string searchText)
        {
            var result = await _employeeRepository.SearchEmployees(searchText);

            if(result == null || result.Count <= 0)
                throw new InvalidOperationException("Employees not found.");

            return _mapper.Map<List<EmployeeDto>>(result);
        }

        public async Task<EmployeeDto> AddEmployee(EmployeeDto employeeDto)
        {
            if (employeeDto == null)
                throw new ArgumentNullException(nameof(employeeDto), "Product cannot be null.");

            if (string.IsNullOrWhiteSpace(employeeDto.FullName))
                throw new ArgumentException("Employee's name cannot be empty or null.", nameof(employeeDto.FullName));
            if (string.IsNullOrWhiteSpace(employeeDto.Position))
                throw new ArgumentException("Employee's position cannot be empty or null.", nameof(employeeDto.Position));

            var addedEmployee = await _employeeRepository.AddEmployee(_mapper.Map<Employee>(employeeDto));

            return _mapper.Map<EmployeeDto>(addedEmployee);
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid employee ID.", nameof(id));

            await _employeeRepository.DeleteEmployee(id);
            return true;
        }

        public async Task<EmployeeDto> UpdateEmployee(EmployeeDto employeeDto)
        {
            if (employeeDto == null)
                throw new ArgumentNullException(nameof(employeeDto), "Product cannot be null.");

            if (string.IsNullOrWhiteSpace(employeeDto.FullName))
                throw new ArgumentException("Employee's name cannot be empty or null.", nameof(employeeDto.FullName));
            if (string.IsNullOrWhiteSpace(employeeDto.Position))
                throw new ArgumentException("Employee's position cannot be empty or null.", nameof(employeeDto.Position));

            var updatedEmployee = await _employeeRepository.UpdateEmployee(_mapper.Map<Employee>(employeeDto));

            return _mapper.Map<EmployeeDto>(updatedEmployee);
        }
    }
}
