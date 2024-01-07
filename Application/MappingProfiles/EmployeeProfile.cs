using Application.Features.Employee.Commands.CreateEmployee;
using Application.Features.Employee.Commands.UpdateEmployee;
using Application.Features.Employee.Shared;
using AutoMapper;
using Domain;

namespace Application.MappingProfiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Employee, CreateEmployeeCommand>().ReverseMap();
            CreateMap<Employee, UpdateEmployeeCommand>().ReverseMap();
        }
    }
}
