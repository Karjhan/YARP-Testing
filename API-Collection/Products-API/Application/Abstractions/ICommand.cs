using Commons.Primitives;
using MediatR;

namespace Products_API.Application.Abstractions;

public interface ICommand : IRequest<Result>
{
    
}

public interface ICommand<TResponse> : IRequest<TResponse>
{
    
}