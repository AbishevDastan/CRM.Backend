using Application.Features.TaskItem.Commands.CreateTaskItem;
using Application.Features.TaskItem.Commands.UpdateTaskItem;
using Application.Features.TaskItem.Queries.GetTaskItemDetails;
using Application.Features.TaskItem.Shared;
using AutoMapper;
using Domain;

namespace Application.MappingProfiles
{
    public class TaskItemProfile : Profile
    {
        public TaskItemProfile()
        {
            CreateMap<TaskItem, TaskItemDto>().ReverseMap();
            CreateMap<TaskItem, CreateTaskItemCommand>().ReverseMap();
            CreateMap<TaskItem, UpdateTaskItemCommand>().ReverseMap();
        }
    }
}
