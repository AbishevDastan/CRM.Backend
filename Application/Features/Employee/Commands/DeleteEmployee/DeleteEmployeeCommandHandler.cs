using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.Employee.Commands.CreateEmployee;
using MediatR;

namespace Application.Features.Employee.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, Unit>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteEmployeeCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid employee", validationResult);

            var employeeToDelete = await _employeeRepository.GetById(request.Id);

            if (employeeToDelete == null)
                throw new NotFoundException(nameof(Employee), request.Id);

            await _employeeRepository.Delete(employeeToDelete);

            return Unit.Value;
        }
    }
}
