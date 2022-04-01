using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Application.Features.Tasks.Queries.GetTasksList
{
    public class GetTasksListQuery : IRequest<List<MyTaskVm>>
    {
        public string Name { get; set; }

        public GetTasksListQuery(string name)
        {
            Name = name;
        }
    }
}
