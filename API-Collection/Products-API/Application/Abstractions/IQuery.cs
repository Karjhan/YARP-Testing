using Commons.Primitives;
using MediatR;

namespace Products_API.Application.Abstractions;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
    
}