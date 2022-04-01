using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Application.Features.Tasks.Commands.AddTask;
using Task.Application.Features.Tasks.Queries.GetTasksList;
using Task.Domain.Entities;

namespace Task.Application.Mappings
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<MyTask, MyTaskVm>().ReverseMap();
            CreateMap<MyTask, AddTaskCommand>().ReverseMap();
            //CreateMap<MyTask, UpdateMyTaskCommand>().ReverseMap();
        }
        
    }
}
