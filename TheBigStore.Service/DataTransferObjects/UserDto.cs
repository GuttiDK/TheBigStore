using System.ComponentModel.DataAnnotations;

namespace TheBigStore.Repository.Models
{
    public class UserDto
    {
        public int Id { get; set; }

        // User
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        // Role
        public int RoleId { get; set; } = 0;
        public RoleDto Role { get; set; } = new RoleDto();

        // Customer
        public int CustomerId { get; set; } = 0;
        public Customer Customer { get; set; } = new Customer();
    }
}
