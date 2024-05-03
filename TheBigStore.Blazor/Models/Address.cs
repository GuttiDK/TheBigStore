using System.ComponentModel.DataAnnotations;

namespace TheBigStore.Blazor.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string City { get; set; } 
        public string ZipCode { get; set; }
        public string Country { get; set; }
    }
}
