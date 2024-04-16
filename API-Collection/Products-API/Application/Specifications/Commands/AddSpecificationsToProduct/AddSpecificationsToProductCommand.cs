using Products_API.Application.Abstractions;
using Products_API.Application.Specifications.DTOs;

namespace Products_API.Application.Specifications.Commands.AddSpecificationsToProduct;

public sealed record AddSpecificationsToProductCommand(
    Guid ProductId, 
    IEnumerable<SpecificationResponse> Specifications
) : ICommand;