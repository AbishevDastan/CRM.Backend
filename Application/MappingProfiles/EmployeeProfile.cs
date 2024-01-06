using Application.Features.Employee.Commands.CreateEmployee;
using Application.Features.Employee.Commands.UpdateEmployee;
using Application.Features.Employee.Queries.GetAllEmployees;
using Application.Features.Employee.Queries.GetEmployeeDetails;
using AutoMapper;
using Domain;

namespace Application.MappingProfiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Employee, EmployeeDetailsDto>().ReverseMap();
            CreateMap<Employee, CreateEmployeeCommand>().ReverseMap();
            CreateMap<Employee, UpdateEmployeeCommand>().ReverseMap();
        }
    }
}
