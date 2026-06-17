namespace Ecom.Models
{
    public class UserRole
    {
        public int RoleId { get; set; }

        public Role ? Role { get; set; }

        public int UserId { get; set; }

        public Users? User { get; set; }
    }
}
