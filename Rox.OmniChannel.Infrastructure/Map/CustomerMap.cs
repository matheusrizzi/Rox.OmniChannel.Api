using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rox.OmniChannel.Domain.Models;

namespace Rox.OmniChannel.Infrastructure.Map;

public class CustomerMap : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");

        builder.HasKey(ut => new { ut.Id, ut.Cpf });

        builder.HasOne(ut => ut.User)
            .WithMany(u => u.Customers)
            .HasForeignKey(ut => ut.AspNetUserId);

        builder.HasOne(ut => ut.Tenant)
            .WithMany(t => t.Customers)
            .HasForeignKey(ut => ut.TenantId);
    }
}
