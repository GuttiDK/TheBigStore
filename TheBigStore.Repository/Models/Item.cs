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
        public int Quantity { get; set; }
        public int? CategoryId { get; set; } // FK
        public int? ImageId { get; set; } // FK

        // Navigations 
        public Category? Category { get; set; }
        public Image? Image { get; set; }
    }
}
