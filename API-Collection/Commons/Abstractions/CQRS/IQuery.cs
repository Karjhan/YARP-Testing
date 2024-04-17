using Commons.Primitives;
using MediatR;

namespace Reports_API.Application.Abstractions;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
    
}