using Commons.Primitives;
using MediatR;

namespace Reports_API.Application.Abstractions;

public interface ICommandHandler<TCommand> : IRequestHandler<TCommand,Result> 
    where TCommand : ICommand
{
    
}

public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>> 
    where TCommand : ICommand<TResponse>, IRequest<Result<TResponse>>
{
    
}