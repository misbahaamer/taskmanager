using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Task.Application.Contracts.Persistence;

namespace Task.Application.Behaviours
{
    public class SystemValidation<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        private readonly ITaskRepository _taskRepository;


        public SystemValidation(IEnumerable<IValidator<TRequest>> validators, ITaskRepository taskRepository)
        {
            _validators = validators;
            _taskRepository = taskRepository;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var failedValidations = await _taskRepository.GetAsync(x => x.Priority.ToLower() == "High".ToLower() && x.Status.ToLower() != "Finished".ToLower() && x.DueDate == DateTime.Today);
            if (failedValidations.Count > 100)
            {
                throw new ValidationException("UnFinished High Priority Tasks have exceeded 100 today: " + request.ToString());
            }

            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var validationResults = await System.Threading.Tasks.Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();
                

                if (failures.Count != 0)
                {
                    throw new ValidationException(failures);
                }
                    
                
            }
            return await next();
        }
    }
}
