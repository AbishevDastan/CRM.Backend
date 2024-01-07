using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;
using Shouldly;

namespace CRM.Backend.IntegrationTests
{
    public class CrmDatabaseContextTests
    {
        private CrmDatabaseContext _crmDatabaseContext;

        public CrmDatabaseContextTests()
        {
            var dbOptions = new DbContextOptionsBuilder<CrmDatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            _crmDatabaseContext = new CrmDatabaseContext(dbOptions);
        }

        [Fact]
        public async void SetDateCreatedValue()
        {
            var employee = new Employee { Id = 1, FullName = "Dastan Abishev", Position = "Senior Full Stack Developer" };

            await _crmDatabaseContext.Employees.AddAsync(employee);
            await _crmDatabaseContext.SaveChangesAsync();

            employee.DateCreated.ShouldNotBeNull();
        }

        [Fact]
        public async void SetDateModifiedValue()
        {
            var employee = new Employee { Id = 1, FullName = "Dastan Abishev", Position = "Senior Full Stack Developer" };

            await _crmDatabaseContext.Employees.AddAsync(employee);
            await _crmDatabaseContext.SaveChangesAsync();

            employee.DateModified.ShouldNotBeNull();
        }
    }
}
