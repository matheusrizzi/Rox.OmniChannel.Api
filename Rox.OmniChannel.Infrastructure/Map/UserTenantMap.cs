using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rox.OmniChannel.Domain.Models;

namespace Rox.OmniChannel.Infrastructure.Map;

public class UserTenantMap : IEntityTypeConfiguration<UserTenant>
{

    public void Configure(EntityTypeBuilder<UserTenant> builder)
    {
        builder.HasKey(ut => new { ut.UserId, ut.TenantId });

        builder.HasOne(ut => ut.User)
            .WithMany(u => u.UserTenants)
            .HasForeignKey(ut => ut.UserId);

        builder.HasOne(ut => ut.Tenant)
            .WithMany(t => t.UserTenants)
            .HasForeignKey(ut => ut.TenantId);
    }
}
