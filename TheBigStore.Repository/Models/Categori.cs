using System.ComponentModel.DataAnnotations;

namespace TheBigStore.Repository.Models
{
    public class Categori
    {
        [Key]
        public int Id { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }
}
