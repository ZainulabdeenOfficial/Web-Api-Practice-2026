using System.ComponentModel.DataAnnotations;

namespace Ecom.Dto.Auth_Dtos
{
    public class RegestraionRequestDto
    {
        [Required]
       
        public string UserName { get; set; } = string.Empty;
        [Required]
        public string UserEmail { get; set; } = string.Empty;
        [Required]

        public string Password { get; set; }

        [Required]
        [Compare("Password")]

        public string ComformPassword { get; set; } = string.Empty;

        [Required]

        public List <int> ? RoleId { get; set; }

    }
}
