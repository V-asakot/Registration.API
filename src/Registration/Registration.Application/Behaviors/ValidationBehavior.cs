using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Registration.Domain.Primitives;

namespace Registration.Application.Behaviors
{
    public sealed class ValidationBehavior<TRequest, TResult> : IPipelineBehavior<TRequest, TResult> where TResult: Result
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;
        public async Task<TResult> Handle(TRequest request, RequestHandlerDelegate<TResult> next, CancellationToken cancellationToken)
        {
            if (!_validators.Any())
            {
                return await next();
            }
            var context = new ValidationContext<TRequest>(request);
            var errors = _validators
                .Select(x => x.Validate(context))
                .SelectMany(x => x.Errors)
                .Where(x => x != null)
                .Select(x => x.ErrorMessage).ToArray();

            if (errors.Any())
            {
                return CreateValidationResult<TResult>(errors);
            }
            return await next();
        }

        private TResult CreateValidationResult<TResult>(IEnumerable<string> errors) where TResult : Result 
        {
            if (typeof(TResult) == typeof(Result))
            {
                return (Result.FailMany(errors) as TResult)!;
            }

            return (TResult) ReflectGeneric(errors);
        }

        private object? ReflectGeneric(IEnumerable<string> errors)
        {
            var constructor = typeof(Result<>)
                .GetGenericTypeDefinition()
                .MakeGenericType(typeof(TResult).GenericTypeArguments[0])
                .GetConstructor(
                    new[] { typeof(TResult).GenericTypeArguments[0], typeof(bool), typeof(IEnumerable<string>) }); ;

            return constructor.Invoke(new object?[] { null, false, errors });
        }

    }
}
