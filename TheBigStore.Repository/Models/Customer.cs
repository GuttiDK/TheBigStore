using System.ComponentModel.DataAnnotations;

namespace TheBigStore.Repository.Models
{
    // Make a fully functional Customer domain class
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public int AddressId { get; set; }
        public Address Address { get; set; } = new Address();

    }
}
