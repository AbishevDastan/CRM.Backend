using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.Employee.Queries.GetAllEmployees;
using AutoMapper;
using MediatR;

namespace Application.Features.Employee.Queries.SearchEmployees
{
    public class SearchEmployeesQueryHandler : IRequestHandler<SearchEmployeesQuery, List<EmployeeDto>>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;

        public SearchEmployeesQueryHandler(IMapper mapper,
            IEmployeeRepository employeeRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }

        public async Task<List<EmployeeDto>> Handle(SearchEmployeesQuery request, CancellationToken cancellationToken)
        {
            var validator = new SearchEmployeesQueryValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid search input.", validationResult);

            var searchResult = await _employeeRepository.SearchEmployees(request.SearchText);

            return _mapper.Map<List<EmployeeDto>>(searchResult);
        }
    }
}
