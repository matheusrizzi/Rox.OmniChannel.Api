using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rox.OmniChannel.Domain.Models;

namespace Rox.OmniChannel.Infrastructure.Map;

public class TenantMap : IEntityTypeConfiguration<Tenant>
{
    public void Configure(EntityTypeBuilder<Tenant> builder)
    {
        builder.ToTable("Tenants");
        builder.HasKey(k=> k.Id);
        builder.HasData(new Tenant() { Id = "e67796b4-2679-418f-a67e-6a8b1d604da2", Name = "Rox" });
    }
}
