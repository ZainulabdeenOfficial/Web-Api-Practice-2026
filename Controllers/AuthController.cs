using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("Login")]
        public  IActionResult Login ()
        {
                       return Ok("Login successful");

        }
        [HttpPost("Regitser")]
        public IActionResult Register()
        {
            return Ok(" Regitser  successful");

        }
    }
}
