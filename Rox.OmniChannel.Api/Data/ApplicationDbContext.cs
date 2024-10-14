//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;
//using Rox.OmniChannel.Api.Models;

//namespace Rox.OmniChannel.Api.Data;

//public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
//{
//    public DbSet<Tenant> Tenants { get; set; }
//    public DbSet<UserTenant> UserTenants { get; set; }

//    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
//        : base(options)
//    {
//    }

//    protected override void OnModelCreating(ModelBuilder builder)
//    {
//        base.OnModelCreating(builder);

//        builder.Entity<UserTenant>()
//            .HasKey(ut => new { ut.UserId, ut.TenantId });

//        builder.Entity<UserTenant>()
//            .HasOne(ut => ut.User)
//            .WithMany(u => u.UserTenants)
//            .HasForeignKey(ut => ut.UserId);

//        builder.Entity<UserTenant>()
//            .HasOne(ut => ut.Tenant)
//            .WithMany(t => t.UserTenants)
//            .HasForeignKey(ut => ut.TenantId);
//    }
//}

