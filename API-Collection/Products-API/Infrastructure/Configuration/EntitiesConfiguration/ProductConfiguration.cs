using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products_API.Domain.Entities;

namespace Products_API.Infrastructure.Configuration.EntitiesConfiguration;

public class ProductConfiguration: IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(user => user.Id);

        builder
            .HasMany(product => product.Specifications)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade)
            .HasForeignKey(specification => specification.Id)
            .IsRequired();
    }
}