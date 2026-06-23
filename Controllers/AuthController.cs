using Ecom.Data;
using Ecom.Dto.Auth_Dtos;
using Ecom.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly EcommerceDataDbContext _DbContext;

        public AuthController(EcommerceDataDbContext DbContext)
        {
            _DbContext = DbContext;

        }



        [HttpPost("Login")]
        public IActionResult Login ()
        {
              return Ok("Login successful");

        }
        [HttpPost("Regitser")]
        public async Task <IActionResult> Register([FromBody] RegestraionRequestDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid registration data.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var HashPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);
            if (dto.RoleId == null || !dto.RoleId.Any())
            {
                return BadRequest("RoleID is required.");
            }

            var ValidateRole = await _DbContext.Roles
                .Where(r => dto.RoleId.Contains(r.RoleId))
                .Select(r => r.RoleId)
                .ToListAsync();

            if (ValidateRole.Count != dto.RoleId.Count)
            {
                return BadRequest("One or more invalid role IDs.");
            }

            Users usercreate = new Users
            {
               UserName = dto.UserName,
                UserEmail = dto.UserEmail,
                Password = HashPassword,
                UsersRole = ValidateRole.Select(roleId => new UserRole
                {
                    RoleId = roleId
                }).ToList()

            };
          await _DbContext.Users.AddAsync(usercreate);
          await _DbContext.SaveChangesAsync();

          return Ok("Registration successful");


        }
    }
}

