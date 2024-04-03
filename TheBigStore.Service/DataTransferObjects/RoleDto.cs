using System.ComponentModel.DataAnnotations;

namespace TheBigStore.Repository.Models
{
    public class RoleDto
    {
        public int Id { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public List<UserDto> Users { get; set; } = [];
    }
}
