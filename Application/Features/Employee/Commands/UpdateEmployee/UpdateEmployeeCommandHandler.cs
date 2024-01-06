using Application.Contracts.Logging;
using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.Employee.Commands.CreateEmployee;
using AutoMapper;
using MediatR;

namespace Application.Features.Employee.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IAppLogger<UpdateEmployeeCommandHandler> _logger;

        public UpdateEmployeeCommandHandler(IMapper mapper,
            IEmployeeRepository employeeRepository,
            IAppLogger<UpdateEmployeeCommandHandler> logger)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateEmployeeCommandValidator(_employeeRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(Employee), request.Id);
                throw new BadRequestException("Invalid employee data", validationResult);
            }

            var employeeToUpdate = _mapper.Map<Domain.Employee>(request);

            await _employeeRepository.Update(employeeToUpdate);

            return Unit.Value;
        }
    }
}
