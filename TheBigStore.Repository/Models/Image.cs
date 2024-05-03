using System.ComponentModel.DataAnnotations;

namespace TheBigStore.Repository.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DateCreated { get; set; }

        // Navigation Properties
        public Item? Item { get; set; }
    }
}
