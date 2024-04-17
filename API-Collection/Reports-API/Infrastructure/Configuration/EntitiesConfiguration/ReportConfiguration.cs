using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reports_API.Domain.Entities;

namespace Reports_API.Infrastructure.Configuration.EntitiesConfiguration;

public class ReportConfiguration: IEntityTypeConfiguration<Report>
{
    public void Configure(EntityTypeBuilder<Report> builder)
    {
        builder.ToTable("Reports");

        builder.HasKey(user => user.Id);
    }
}