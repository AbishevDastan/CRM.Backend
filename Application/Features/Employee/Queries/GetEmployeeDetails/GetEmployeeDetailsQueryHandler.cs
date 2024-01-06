using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using MediatR;

namespace Application.Features.Employee.Queries.GetEmployeeDetails
{
    public class GetEmployeeDetailsQueryHandler : IRequestHandler<GetEmployeeDetailsQuery,
        EmployeeDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeeDetailsQueryHandler(IMapper mapper,
            IEmployeeRepository employeeRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }

        public async Task<EmployeeDetailsDto> Handle(GetEmployeeDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var validator = new GetEmployeeDetailsQueryValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid employee", validationResult);

            var employee = await _employeeRepository.GetById(request.Id);

            if (employee == null)
                throw new NotFoundException(nameof(Employee), request.Id);

            return _mapper.Map<EmployeeDetailsDto>(employee);
        }
    }
}
