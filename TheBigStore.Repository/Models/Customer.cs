using System.ComponentModel.DataAnnotations;

namespace TheBigStore.Repository.Models
{
    // Make a fully functional Customer domain class
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        // Add a first name, last name, email, and phone number
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public int AddressId { get; set; }

        // Add an address
        public Address Address { get; set; } = new Address();

        // Add a list of orders
        public List<Order> Orders { get; set; } = [];

        // Add a user
        public User User { get; set; } = new User();
        public int UserId { get; set; }
    }
}
