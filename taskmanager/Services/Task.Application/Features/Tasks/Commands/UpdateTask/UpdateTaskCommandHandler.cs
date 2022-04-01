using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Task.Application.Contracts.Persistence;
using Task.Domain.Entities;

namespace Task.Application.Features.Tasks.Commands.UpdateTask
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateTaskCommandHandler> _logger;

        public UpdateTaskCommandHandler(ITaskRepository taskRepository, IMapper mapper, ILogger<UpdateTaskCommandHandler> logger)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var taskToUpdate = await _taskRepository.GetByIdAsync(request.Id);
            if (taskToUpdate == null)
            {
                _logger.LogError("Task doesnot exist in the database");
            }
            _mapper.Map(request, taskToUpdate, typeof(UpdateTaskCommand), typeof(MyTask));
            await _taskRepository.UpdateAsync(taskToUpdate);
            _logger.LogInformation($"Task {taskToUpdate.Id} is updated successfully");

            return Unit.Value;


        }
    }
}
