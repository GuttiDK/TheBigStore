using TheBigStore.Repository.Models;

namespace TheBigStore.Service.DataTransferObjects
{
    public class ItemDto
    {

        public int Id { get; set; } // PK

        // Item
        public string ItemName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public int Quantity { get; set; }
        public int? CategoryId { get; set; } // FK
        public int? ImageId { get; set; } // FK

        // Navigations 
        public CategoryDto? Category { get; set; }
        public ImageDto? Image { get; set; }
    }
}
