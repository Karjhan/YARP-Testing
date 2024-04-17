using Products_API.Application.Specifications.DTOs;
using Reports_API.Application.Abstractions;

namespace Products_API.Application.Specifications.Commands.AddSpecificationsToProduct;

public sealed record AddSpecificationsToProductCommand(
    Guid ProductId, 
    IEnumerable<SpecificationResponse> Specifications
) : ICommand;