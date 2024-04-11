using System.ComponentModel.DataAnnotations;

namespace TheBigStore.Repository.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        // CategoryName
        public string CategoryName { get; set; }
        public List<Item>? Items { get; set; }
    }
}
