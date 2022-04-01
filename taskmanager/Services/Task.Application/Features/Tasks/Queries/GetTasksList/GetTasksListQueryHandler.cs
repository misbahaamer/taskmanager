using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task.Application.Features.Tasks.Queries.GetTasksList
{
    public class GetTasksListQueryHandler : IRequestHandler<GetTasksListQuery, List<MyTaskVm>>
    {
        public Task<List<MyTaskVm>> Handle(GetTasksListQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
