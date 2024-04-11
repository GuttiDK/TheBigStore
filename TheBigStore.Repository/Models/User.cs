using System.ComponentModel.DataAnnotations;

namespace TheBigStore.Repository.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        // User
        public string UserName { get; set; }
        public string Password { get; set; } 
        public string Email { get; set; }

        // Role
        public int RoleId { get; set; }
        public Role Role { get; set; }

        // Customer
        public int? CustomerId { get; set; } 
        public Customer? Customer { get; set; }
    }
}
