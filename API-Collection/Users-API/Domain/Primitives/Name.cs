using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace Users_API.Domain.Primitives;

[ComplexType]
public sealed record Name(string ShortName, string? LongName)
{
    public override string ToString()
    {
        if (string.IsNullOrEmpty(LongName))
        {
            return ShortName;
        }

        return $"{ShortName} {LongName}";
    }
}

