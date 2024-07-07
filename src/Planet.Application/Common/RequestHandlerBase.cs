using MediatR;

namespace Planet.Application.Common
{
    public abstract class RequestHandlerBase<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : RequestBase<TResponse>
        where TResponse : ResponseBase
    {
        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
