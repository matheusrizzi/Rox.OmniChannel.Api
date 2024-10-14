﻿namespace Rox.OmniChannel.Domain.Models;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Cpf { get; set; }
    public string Email { get; set; }
    public string AspNetUserId { get; set; }
    public string TenantId { get; set; }

    public Tenant Tenant { get; set; }
    public ApplicationUser User { get; set; }
}
