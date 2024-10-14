using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Rox.OmniChannel.Api.Controllers;

[Authorize(Roles = "Cliente")]
public class ClientController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
