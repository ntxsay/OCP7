using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace P7CreateRestApi.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }

    [Authorize]
    [HttpGet]
    [Route("Admin")]
    public IActionResult Admin()
    {
        return Ok();
    }
}