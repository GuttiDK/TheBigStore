namespace TheBigStore.Service.DataTransferObjects
{
    // Make a fully functional Customer domain class
    public class CustomerDto
    {
        public int Id { get; set; }
        // Add a first name, last name, email, and phone number
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; } 
        public string Phone { get; set; }
        public int? AddressId { get; set; }

        // Navigation properties
        public AddressDto? Address { get; set; }
        public List<OrderDto> Orders { get; set; }
    }
}
