using Application.Contracts.Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;
using Persistence.Repositories.Common;

namespace Infrastructure.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(CrmDatabaseContext context) : base(context)
        {
        }

        public async Task<List<Employee>> SearchEmployees(string searchText)
        {
            return await _context.Employees
                .Where(e => e.FullName.ToLower().Contains(searchText.ToLower()))
                .ToListAsync();
        }
    }
}
