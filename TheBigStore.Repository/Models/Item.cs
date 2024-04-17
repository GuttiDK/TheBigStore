using System.ComponentModel.DataAnnotations;

namespace TheBigStore.Repository.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; } // PK

        // Item
        public string ItemName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }

        // Navigations Property

        // ItemOrder
        public List<ItemOrder>? ItemOrders { get; set; }
        
        // Category
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        // Image
        public int? ImageId { get; set; } // FK
        public Image? Image { get; set; }
        public int Quantity { get; set; }
    }
}
