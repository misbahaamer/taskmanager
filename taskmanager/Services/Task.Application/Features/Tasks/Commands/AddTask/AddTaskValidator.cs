using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Application.Contracts.Persistence;

namespace Task.Application.Features.Tasks.Commands.AddTask
{
    public class AddTaskValidator : AbstractValidator<AddTaskCommand>
    {

        //new task due date cannot be in the past
        public AddTaskValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("{Name} is required");
            RuleFor(x => x.DueDate).NotEmpty().NotNull().GreaterThanOrEqualTo(DateTime.Today).WithMessage("{DueDate} is required");
            RuleFor(x => x.Priority).NotEmpty().NotNull().WithMessage("{Priority} is required");
            RuleFor(x => x.Status).NotEmpty().NotNull().WithMessage("{Status} is required");
        }

       
    }
}
