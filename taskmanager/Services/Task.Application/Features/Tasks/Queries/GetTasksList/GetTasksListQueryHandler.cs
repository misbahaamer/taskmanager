using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Task.Application.Contracts.Persistence;

namespace Task.Application.Features.Tasks.Queries.GetTasksList
{
    public class GetTasksListQueryHandler : IRequestHandler<GetTasksListQuery, List<MyTaskVm>>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public GetTasksListQueryHandler(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<List<MyTaskVm>> Handle(GetTasksListQuery request, CancellationToken cancellationToken)
        {
            var taskList = await _taskRepository.GetAllAsync();
            return _mapper.Map<List<MyTaskVm>>(taskList);

        }
    }
}
