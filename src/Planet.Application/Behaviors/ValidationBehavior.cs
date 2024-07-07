using FluentValidation;
using MediatR;
using Planet.Application.Common;

namespace Planet.Application.Behaviors
{
    public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : RequestBase<TResponse>
        where TResponse : ResponseBase
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);
            var results = await Task.WhenAll(_validators.Select(validator => validator.ValidateAsync(context)));
            var errors = results.Where(validationResult => !validationResult.IsValid)
                .SelectMany(validationResult => validationResult.Errors);

            if (errors.Any())
            {
                var response = (TResponse)Activator.CreateInstance(typeof(TResponse));
                response.Header ??= new Header();
                response.Header.IsSuccess = false;
                response.Header.ValidationMessages = errors.Select(e => new ValidationMessage { Code = e.ErrorCode, Message = e.ErrorMessage }).ToList();

                return response;
            }

            return await next();
        }
    }
}
