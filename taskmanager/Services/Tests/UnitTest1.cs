using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Net;
using Task.API.Controllers;
using Task.Application.Features.Tasks.Commands.AddTask;
using Task.Application.Features.Tasks.Commands.UpdateTask;
using Xunit;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public async void Get_Tasks_Returns_Ok_200()
        {
            //arrange
            var mediatr = new Mock<IMediator>();
            var sut = new TaskController(mediatr.Object);
            //act
            var res = await sut.GetTasks();
            Assert.IsType<OkObjectResult>(res.Result);
        }

        [Fact]
        public async void AddTask_Returns_Ok_200()
        {
            //arrange
            var mediatr = new Mock<IMediator>();
            var sut = new TaskController(mediatr.Object);
            var command = new AddTaskCommand();
            command.Name = "Name: " + DateTime.Today.Date.ToShortDateString();
            command.Description = "Description: " + DateTime.Today.TimeOfDay.ToString();
            command.DueDate = DateTime.Today;
            command.Priority = "High";
            command.Status = "Finished";
            //act
            var res =  await sut.AddTask(command);
            
            //assert
            Assert.IsType<OkObjectResult>(res.Result);
        }
        [Fact]
        public async void UpdateTask_With_TaskId_Returns_204_NoContent()
        {
            //arrange
            var mediatr = new Mock<IMediator>();
            var sut = new TaskController(mediatr.Object);
            var command = new UpdateTaskCommand();
            command.Id = 1;
            command.Name = "Name: " + DateTime.Today.Date.ToShortDateString();
            command.Description = "Description: " + DateTime.Today.TimeOfDay.ToString();
            command.DueDate = DateTime.Today;
            command.Priority = "High";
            command.Status = "Finished";
            //act
            var res = await sut.UpdateTask(command);

            //assert
            Assert.IsType<NoContentResult>(res);
        }
      
    }
}
