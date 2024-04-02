using System.ComponentModel.DataAnnotations;

namespace TheBigStore.Repository.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        // Item
        public string ItemName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0;
        public int Stock { get; set; } = 0;

        // ItemOrder
        public List<ItemOrder> ItemOrders { get; set; } = [];
        
        // Category
        public int CategoryId { get; set; }
        public Category Category { get; set; } = new Category();
    }
}
