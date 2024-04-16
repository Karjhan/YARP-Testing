using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products_API.Domain.Entities;

namespace Products_API.Infrastructure.Configuration.EntitiesConfiguration;

public class SpecificationConfiguration : IEntityTypeConfiguration<Specification>
{
    public void Configure(EntityTypeBuilder<Specification> builder)
    {
        builder.ToTable("Specifications");

        builder.HasIndex(specification => new { specification.Id, specification.Title }).IsUnique();
        
        builder.HasKey(specification => new { specification.Id, specification.Title });
        
        builder.Property(specification => specification.Id).HasColumnName("ProductId");
    }
}