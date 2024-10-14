using Microsoft.AspNetCore.Mvc;
using Rox.OmniChannel.Api.ViewModels;
using Rox.OmniChannel.Domain.Models;

namespace Rox.OmniChannel.Api.Controllers;

public class UserController : Controller
{
    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            //var result = await _userManager.CreateAsync(user, model.Password);
            return CreatedAtAction(nameof(Register), new { email = user.Email });

            //if (result.Succeeded)
            //{
            //    //var role = model.IsAdmin ? "Admin" : "Cliente";
            //    //await _userManager.AddToRoleAsync(user, role);
            //    // Associar o usuário aos tenants, se necessário.

            //    // Retorna uma resposta de sucesso com o status 201 (Created)
            //    return CreatedAtAction(nameof(Register), new { email = user.Email });
            //}
        }
        return BadRequest(ModelState);
    }

}
