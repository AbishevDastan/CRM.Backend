using Domain.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await _dbContext.Employees.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return await _dbContext.Employees.ToListAsync();
        }

        public async Task<List<Employee>> SearchEmployees(string searchText)
        {
            return await _dbContext.Employees
                .Where(e => e.FullName.ToLower().Contains(searchText.ToLower()))
                .ToListAsync();
        }

        //public async Task<List<string>> GetEmployeeSearchSuggestions(string searchText)
        //{
        //    var items = await SearchItem(searchText);

        //    List<string> result = new List<string>();

        //    foreach (var item in items)
        //    {
        //        if (item.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase))
        //        {
        //            result.Add(item.Name);
        //        }
        //    }
        //    return new List<string>(result);
        //}

        public async Task<Employee> AddEmployee(Employee employee)
        {
            await _dbContext.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
            return employee;
        }

        public async Task DeleteEmployee(int id)
        {
            var employee = await GetEmployee(id);

            _dbContext.Employees.Remove(employee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var dbEmployee = await GetEmployee(employee.Id);

            if (dbEmployee != null)
            {
                dbEmployee.FullName = employee.FullName;
                dbEmployee.Position = employee.Position;

                await _dbContext.SaveChangesAsync();
                return dbEmployee;
            }

            throw new ArgumentNullException(nameof(employee));
        }
    }
}
