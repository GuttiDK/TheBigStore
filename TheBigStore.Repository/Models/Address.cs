using System.ComponentModel.DataAnnotations;

namespace TheBigStore.Repository.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string City { get; set; } 
        public string ZipCode { get; set; }
        public string Country { get; set; }
    }
}
