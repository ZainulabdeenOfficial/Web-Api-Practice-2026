using Ecom.Data;
using Ecom.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        // used it for add acces om db 
        private readonly EcommerceDataDbContext _context;

        public RolesController(EcommerceDataDbContext context)
        {
            _context = context ;
        }

        [HttpPost]

        public async Task<IActionResult> Create([FromBody] Role role )
        {
            if (role == null)
            {
                return BadRequest();
            }
            
            Role NewRole = new Role
                {
                    RoleName = role.RoleName,
                    
                };

                await _context.AddAsync(NewRole);

                await _context.SaveChangesAsync();

                return Ok();
            

        }

        [HttpGet]

        public async Task<IActionResult> GetAllRoles()
        {
          var roleslist =   _context.Roles.ToList();
            return Ok(roleslist);
        }

    }
}
