using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Domain.Entities;

namespace Task.Application.Mappings
{
    public class MappingProfile : Profile
    {
        CreateMap<MyTask, MyTaskVm>().ReverseMap();
        CreateMap<MyTask, AddMyTaskCommand>().ReverseMap();
        CreateMap<MyTask, UpdateMyTaskCommand>().ReverseMap();
    }
}
