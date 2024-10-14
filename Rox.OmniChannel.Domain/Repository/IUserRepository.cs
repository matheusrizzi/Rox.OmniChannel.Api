using Microsoft.AspNetCore.Identity;
using Rox.OmniChannel.Domain.Dtos;
using Rox.OmniChannel.Domain.Models;

namespace Rox.OmniChannel.Domain.Repository;

public interface IUserRepository
{
    Task<IdentityResult> AddUserAsync(CreateUserDto createUserDto);
}
