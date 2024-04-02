using System.ComponentModel.DataAnnotations;

namespace TheBigStore.Repository.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
