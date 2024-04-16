namespace TheBigStore.Service.DataTransferObjects
{
    // Make a fully functional Customer domain class
    public class CustomerDto
    {
        public int Id { get; set; }
        // Add a first name, last name, email, and phone number
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public int? AddressId { get; set; }

        // Add an address
        public AddressDto? Address { get; set; }

        // Add a list of orders
        public List<OrderDto> Orders { get; set; } = [];
    }
}
