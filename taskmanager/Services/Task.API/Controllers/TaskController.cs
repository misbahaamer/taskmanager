using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Task.Application.Features.Tasks.Commands.AddTask;
using Task.Application.Features.Tasks.Commands.UpdateTask;
using Task.Application.Features.Tasks.Queries.GetTasksList;

namespace Task.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TaskController : Controller
    {
        private readonly IMediator _mediator;

        public TaskController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet( Name = "GetTasks")]
        [ProducesResponseType(typeof(IEnumerable<MyTaskVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<MyTaskVm>>> GetTasks()
        {
            var query = new GetTasksListQuery();
            var orders = await _mediator.Send(query);
            return Ok(orders);
        }


        [HttpPost(Name = "AddTask")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> AddTask([FromBody] AddTaskCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut(Name = "UpdateTask")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateTask([FromBody] UpdateTaskCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }


    }
}
