using System.ComponentModel.DataAnnotations;

namespace TheBigStore.Blazor.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DateCreated { get; set; }

        // Navigation Properties
        public Item? Item { get; set; }
    }
}
