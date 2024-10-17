using Rox.OmniChannel.CrossCutting.Enums;

namespace Rox.OmniChannel.Domain.Dtos;

public class CreateUserDto
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public List<string> TenantIds { get; set; }
    public string Role { get; set; } = ERoles.Customer;

}
