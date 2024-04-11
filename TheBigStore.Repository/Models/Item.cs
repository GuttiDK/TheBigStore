using System.ComponentModel.DataAnnotations;

namespace TheBigStore.Repository.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        // Item
        public string ItemName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        // ItemOrder
        public List<ItemOrder>? ItemOrders { get; set; }
        
        // Category
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
