using Application.Contracts.Persistence;
using Application.Features.Employee.Shared;
using AutoMapper;
using MediatR;

namespace Application.Features.Employee.Queries.GetAllEmployees
{
    public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery,
        List<EmployeeDto>>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeesQueryHandler(IMapper mapper,
            IEmployeeRepository employeeRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }

        public async Task<List<EmployeeDto>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = await _employeeRepository.GetAll();

            return _mapper.Map<List<EmployeeDto>>(employees);
        }
    }
}
