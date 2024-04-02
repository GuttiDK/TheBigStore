using System.ComponentModel.DataAnnotations;

namespace TheBigStore.Repository.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public List<User> Users { get; set; } = [];
    }
}
