using System.ComponentModel.DataAnnotations;

namespace TheBigStore.Repository.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string CategoryName { get; set; }

        // Navigation properties
        public List<Item> Items { get; set; }
    }
}
