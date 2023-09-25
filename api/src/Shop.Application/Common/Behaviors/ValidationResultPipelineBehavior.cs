using Ardalis.Result;
using FluentValidation;
using Ardalis.Result.FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Shop.Application.Common.Behaviors
{
    public class ValidationResultPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
    {
        private readonly IServiceProvider _serviceProvider;

        public ValidationResultPipelineBehavior(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var validator = _serviceProvider.GetService<IValidator<TRequest>>();

            if (validator != null)
            {

                var result = await validator.ValidateAsync(request, cancellationToken);

                if (!result.IsValid)
                {
                    return (TResponse)(dynamic)Result.Invalid(result.AsErrors());
                }
            }

            return await next();
        }
    }
}
