using System.ComponentModel.DataAnnotations;

namespace TheBigStore.Repository.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string StreetName { get; set; } = string.Empty;
        public string StreetNumber { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
