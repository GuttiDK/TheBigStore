using System.ComponentModel.DataAnnotations;

namespace TheBigStore.Blazor.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public bool IsAdmin { get; set; }
        public List<User>? Users { get; set; }
    }
}
