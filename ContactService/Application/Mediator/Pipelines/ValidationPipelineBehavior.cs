using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ContactService.Exceptions;
using FluentValidation;
using MediatR;

namespace ContactService.Application.Mediator.Pipelines
{
    public class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IValidator<TRequest>[] _validators;

        public ValidationPipelineBehavior(IValidator<TRequest>[] validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {

            var failures = _validators
                .Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(error => error != null)
                .ToList();

            if (failures.Any())
            {
                var error = string.Join("\r\n", failures);
                throw new MediatorValidationException(error);
            }

            return await next();
        }
    }
}
