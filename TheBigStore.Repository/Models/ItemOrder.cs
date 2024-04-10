using System.ComponentModel.DataAnnotations;
using TheBigStore.Repository.Enums;

namespace TheBigStore.Repository.Models
{
    public class ItemOrder
    {
        [Key]
        public int Id { get; set; }

        public int Quantity { get; set; }
        public OrderStatusEnum Status { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
