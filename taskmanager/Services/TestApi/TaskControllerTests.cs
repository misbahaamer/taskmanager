using MediatR;
using System;
using Task.API.Controllers;
using Xunit;

namespace TestApi
{
    public class TaskControllerTests
    {
        private readonly IMediator _mediator;

        public TaskControllerTests(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [Fact]
        public void Get_Tasks_Returns_All_Tasks_Available()
        {
            //Arrange
            var controller = new TaskController(_mediator);
            //act


            //assert
        }
    }
}
