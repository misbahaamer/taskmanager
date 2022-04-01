using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Application.Features.Tasks.Commands.UpdateTask
{
    public class UpdateTaskValidator : AbstractValidator<UpdateTaskCommand>
    {
        
        public UpdateTaskValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("{Name} is required");
            RuleFor(x => x.DueDate).NotEmpty().NotNull().WithMessage("{DueDate} is required");
            RuleFor(x => x.Priority).NotEmpty().NotNull().WithMessage("{Priority} is required");
            RuleFor(x => x.Status).NotEmpty().NotNull().WithMessage("{Status} is required");
        }
    }
}
