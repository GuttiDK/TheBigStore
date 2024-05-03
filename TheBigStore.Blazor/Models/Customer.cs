using System.ComponentModel.DataAnnotations;

namespace TheBigStore.Blazor.Models
{
    // Make a fully functional Customer domain class
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int AddressId { get; set; }
        public int UserId { get; set; }

        // Navigation properties
        public Address? Address { get; set; }
        public List<Order>? Orders { get; set; }
        public User User { get; set; }
    }
}
