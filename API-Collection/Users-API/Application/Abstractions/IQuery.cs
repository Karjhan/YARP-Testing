using Commons.Primitives;
using MediatR;
using Users_API.Domain.Primitives;

namespace Users_API.Application.Abstractions;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
    
}