using MediatR;

namespace Planet.Application.Common
{
    public abstract class RequestBase<TResponse> : IRequest<TResponse> where TResponse : ResponseBase { }
}
