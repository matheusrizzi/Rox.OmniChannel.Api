namespace Rox.OmniChannel.Domain.Models;

public class Tenant
{
    public string Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<UserTenant> UserTenants { get; set; }
    public virtual ICollection<Customer> Customers { get; set; }
}
