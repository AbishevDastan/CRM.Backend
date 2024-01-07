using Application.Contracts.Persistence;
using Application.MappingProfiles;
using AutoMapper;
using CRM.Backend.UnitTests.Mocks;
using Moq;

namespace CRM.Backend.UnitTests.Features.Employees.Queries
{
    public class GetEmployeeDetailsQueryHandlerTests
    {
        private readonly Mock<IEmployeeRepository> _mockRepo;
        private IMapper _mapper;

        public GetEmployeeDetailsQueryHandlerTests()
        {
            _mockRepo = MockEmployeeRepository.GetMockEmployeeRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<EmployeeProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetEmployeeDetailsTest()
        {

        }
    }
}
