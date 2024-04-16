using Commons.Primitives;

namespace Products_API.Domain.Entities;

public class Specification(Guid id) : Entity(id)
{
    public string Title { get; private set; }

    public string? Value { get; private set; } = "N/A";

    public Specification(
        Guid id, 
        string title, 
        string? value) : this(id)
    {
        Title = title;
        Value = value;
    }
    
    public static Specification Create(
        Guid id,
        string title,
        string? value)
    {
        Specification specification = new Specification(
            id, 
            title, 
            value
        );

        return specification;
    }
}