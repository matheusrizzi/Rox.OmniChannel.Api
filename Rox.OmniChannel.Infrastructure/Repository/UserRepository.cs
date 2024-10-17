using Microsoft.AspNetCore.Identity;
using Rox.OmniChannel.Domain.Dtos;
using Rox.OmniChannel.Domain.Models;
using Rox.OmniChannel.Domain.Repository;
using Rox.OmniChannel.Infrastructure.Data;

namespace Rox.OmniChannel.Infrastructure.Repository;

public class UserRepository : IUserRepository
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ApplicationDbContext _dbContext;

    public UserRepository(UserManager<ApplicationUser> userManager, ApplicationDbContext dbContext)
    {
        _userManager = userManager;
        _dbContext = dbContext;
    }

    public async Task<IdentityResult> AddUserAsync(CreateUserDto createUserDto)
    {
        var user = new ApplicationUser
        {
            UserName = createUserDto.UserName,
            Email = createUserDto.Email,
        };

        var result = await _userManager.CreateAsync(user, createUserDto.Password);

        if (result.Succeeded)
        {

            // Verificar e associar a role correta ao usuário
            var role = createUserDto.Role ?? "Customer"; // Caso não seja fornecido, assume que é "Customer"
            await _userManager.AddToRoleAsync(user, role);

            // Associar o usuário aos tenants
            foreach (var tenantId in createUserDto.TenantIds)
            {
                user.UserTenants.Add(new UserTenant
                {
                    UserId = user.Id,
                    TenantId = tenantId
                });
            }

            // Salvar as mudanças no contexto
            await _dbContext.SaveChangesAsync();
        }

        return result;
    }
}
