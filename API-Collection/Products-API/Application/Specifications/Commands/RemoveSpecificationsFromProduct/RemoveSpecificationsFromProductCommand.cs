using Reports_API.Application.Abstractions;

namespace Products_API.Application.Specifications.Commands.RemoveSpecificationsFromProduct;

public record RemoveSpecificationsFromProductCommand(
    Guid ProductId,
    IEnumerable<string> SpecificationTitles
) : ICommand;