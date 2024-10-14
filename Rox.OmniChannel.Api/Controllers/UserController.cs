using Microsoft.AspNetCore.Mvc;
using Rox.OmniChannel.Api.ViewModels;
using Rox.OmniChannel.Domain.Dtos;
using Rox.OmniChannel.Domain.Models;
using Rox.OmniChannel.Domain.Repository;

namespace Rox.OmniChannel.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : Controller
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
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

}
