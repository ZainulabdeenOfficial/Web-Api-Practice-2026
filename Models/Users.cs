using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Ecom.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;

        public string Password { get; set; }


        public ICollection<UserRole>? UsersRole { get; set; }
    }
}
