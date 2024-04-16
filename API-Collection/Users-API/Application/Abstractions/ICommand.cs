using Commons.Primitives;
using MediatR;
using Users_API.Domain.Primitives;

namespace Users_API.Application.Abstractions;

public interface ICommand : IRequest<Result>
{
    
}

public interface ICommand<TResponse> : IRequest<TResponse>
{
    
}