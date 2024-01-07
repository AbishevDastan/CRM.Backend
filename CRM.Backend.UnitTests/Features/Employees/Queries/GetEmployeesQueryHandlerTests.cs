using Application.Contracts.Logging;
using Application.Contracts.Persistence;
using Application.Features.Employee.Queries.GetAllEmployees;
using Application.Features.Employee.Shared;
using Application.MappingProfiles;
using AutoMapper;
using CRM.Backend.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace CRM.Backend.UnitTests.Features.Employees.Queries
{
    public class GetEmployeesQueryHandlerTests
    {
        private readonly Mock<IEmployeeRepository> _mockRepo;
        private IMapper _mapper;

        public GetEmployeesQueryHandlerTests()
        {
            _mockRepo = MockEmployeeRepository.GetMockEmployeeRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<EmployeeProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetEmployeesTest()
        {
            var handler = new GetEmployeesQueryHandler(_mapper, _mockRepo.Object);

            var result = await handler.Handle(new GetEmployeesQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<EmployeeDto>>();
            result.Count.ShouldBe(5);
        }
    }
}
