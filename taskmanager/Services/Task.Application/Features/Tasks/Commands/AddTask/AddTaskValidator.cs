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


        public AddTaskValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("{Name} is required").NotNull();
            RuleFor(x => x.DueDate).NotEmpty().WithMessage("{DueDate} is required").NotNull();
            RuleFor(x => x.Priority).NotEmpty().WithMessage("{Priority} is required").NotNull();
            RuleFor(x => x.Status).NotEmpty().WithMessage("{Status} is required").NotNull();
        }

       
    }
}
