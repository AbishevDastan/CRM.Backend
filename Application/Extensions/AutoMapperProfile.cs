using Application.UseCases.Employee;
using Application.UseCases.TaskItem;
using AutoMapper;
using Domain.Entities;

namespace Application.Extensions
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<AddEmployeeDto, Employee>();
            CreateMap<Employee, AddEmployeeDto>();
            CreateMap<UpdateEmployeeDto, Employee>();
            CreateMap<Employee, UpdateEmployeeDto>();
            CreateMap<EmployeeDto, Employee>();
            CreateMap<TaskItem, TaskItemDto>();
            CreateMap<TaskItemDto, TaskItem>();
        }
    }
}
