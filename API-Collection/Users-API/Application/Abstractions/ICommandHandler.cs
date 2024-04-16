using Commons.Primitives;
using MediatR;
using Users_API.Domain.Primitives;

namespace Users_API.Application.Abstractions;

public interface ICommandHandler<TCommand> : IRequestHandler<TCommand,Result> 
    where TCommand : ICommand
{
    
}

public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>> 
    where TCommand : ICommand<TResponse>, IRequest<Result<TResponse>>
{
    
}