using System.ComponentModel.DataAnnotations;

namespace TheBigStore.Blazor.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        // Navigation properties
        public List<Item> Items { get; set; }
    }
}
