using Microsoft.AspNetCore.Identity;

namespace Rox.OmniChannel.Domain.Models;

public class ApplicationUser : IdentityUser
{
    public virtual ICollection<UserTenant> UserTenants { get; set; }
    public virtual ICollection<Customer> Customers { get; set; }
}

