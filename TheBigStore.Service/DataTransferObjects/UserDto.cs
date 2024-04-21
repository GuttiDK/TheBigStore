using TheBigStore.Repository.Models;

namespace TheBigStore.Service.DataTransferObjects
{
    public class UserDto
    {
        public int Id { get; set; }

        // User
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int? RoleId { get; set; }
        public int? CustomerId { get; set; }

        // Navigation properties
        public RoleDto? Role { get; set; }
        public CustomerDto? Customer { get; set; }
    }
}
