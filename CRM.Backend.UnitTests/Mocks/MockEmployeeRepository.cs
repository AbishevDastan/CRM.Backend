using Application.Contracts.Persistence;
using Domain;
using Moq;

namespace CRM.Backend.UnitTests.Mocks
{
    public class MockEmployeeRepository
    {
        public static Mock<IEmployeeRepository> GetMockEmployeeRepository()
        {
            var employees = new List<Employee>
            {
                new Employee { Id = 1, FullName = "Dastan Abishev", Position = "Senior Full Stack Developer" },
                new Employee { Id = 2, FullName = "Diana Levchenko", Position = "Cloud & Infra Management Engineer" },
                new Employee { Id = 3, FullName = "Damir Abishev", Position = "Musician" },
                new Employee { Id = 4, FullName = "Zhansaya Abishev", Position = "Musician" },
                new Employee { Id = 5, FullName = "Adele Abisheva", Position = "Srygul'" },
            };

            var mockRepo = new Mock<IEmployeeRepository>();

            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(employees);
            mockRepo.Setup(r => r.Create(It.IsAny<Employee>()))
                .Returns((Employee employee) =>
                {
                    employees.Add(employee);
                    return Task.CompletedTask;
                });

            return mockRepo;
        }
    }
}
