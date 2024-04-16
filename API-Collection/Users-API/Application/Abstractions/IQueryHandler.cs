using Commons.Primitives;
using MediatR;
using Users_API.Domain.Primitives;

namespace Users_API.Application.Abstractions;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
    
}