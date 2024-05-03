using TheBigStore.Repository.Models;

namespace TheBigStore.WebAPI.Models
{
    public class ItemModel
    {
        // Item
        public string ItemName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public int Quantity { get; set; }
        public int? CategoryId { get; set; } // FK
        public int? ImageId { get; set; } // FK

        public ImageModel? Image { get; set; }
    }
}
