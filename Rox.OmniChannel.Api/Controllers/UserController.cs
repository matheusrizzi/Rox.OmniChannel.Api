using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Rox.OmniChannel.Api.ViewModels;
using Rox.OmniChannel.Domain.Dtos;
using Rox.OmniChannel.Domain.Models;
using Rox.OmniChannel.Domain.Repository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Rox.OmniChannel.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : Controller
{
    private readonly IUserRepository _userRepository;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;


    public UserController(IUserRepository userRepository, 
                          UserManager<ApplicationUser> userManager, 
                          SignInManager<ApplicationUser> signInManager)
    {
        _userRepository = userRepository;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserDto createUserDto)
    {
        //exemplo do post para colar no swagger
        //{
        //    "userName": "matheusrizzi",
        //    "email": "matheus-rizzi@hotmail.com",
        //    "password": "Mr03123!234",
        //    "tenantIds": [
        //        "e67796b4-2679-418f-a67e-6a8b1d604da2"
        //    ]
        //}

        var result = await _userRepository.AddUserAsync(createUserDto);

        if (result.Succeeded)
        {
            return Ok();
        }

        return BadRequest(result.Errors);
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = await _userManager.Users
                                     .Include(u => u.UserTenants) 
                                     .FirstOrDefaultAsync(u => u.UserName == model.Username);

        if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
        {
            var role = (await _userManager.GetRolesAsync(user)).FirstOrDefault();

            var token = GenerateJwtToken(user, role);
            return Ok(new { token });
        }

        return Unauthorized();
    }

    private string GenerateJwtToken(ApplicationUser user, string role)
    {
        var key = Encoding.ASCII.GetBytes("b7082ed54770844823a4910d7d565b93");

        var claims = new List<Claim>
    {
        new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
        new Claim(ClaimTypes.Role, role),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };
        foreach (var tenant in user.UserTenants)
            claims.Add(new Claim("TenantId", tenant.TenantId));

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
