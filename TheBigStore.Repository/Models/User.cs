using System.ComponentModel.DataAnnotations;

namespace TheBigStore.Repository.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        // User
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        // Role
        public int RoleId { get; set; }
        public Role Role { get; set; } = new Role();

        // Customer
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = new Customer();
    }
}
