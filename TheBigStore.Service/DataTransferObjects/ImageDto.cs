using TheBigStore.Repository.Models;

namespace TheBigStore.Service.DataTransferObjects
{
    public class ImageDto
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DateCreated { get; set; }

        // Navigation Properties
        public ItemDto? Item { get; set; }
    }
}
