using Microsoft.AspNetCore.Identity;

namespace Rox.OmniChannel.Domain.Models;

public class ApplicationUser : IdentityUser
{
    public ApplicationUser()
    {
        UserTenants = new List<UserTenant>(); // Inicializa a coleção
    }
    public virtual ICollection<UserTenant> UserTenants { get; set; }
    public virtual ICollection<Customer> Customers { get; set; }
}

