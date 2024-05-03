using TheBigStore.Blazor.Models.Enums;

namespace TheBigStore.Blazor.Models
{
    public class ItemOrder
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public OrderStatusEnum Status { get; set; }

        // Navigation properties
        public Order Order { get; set; }
        public Item Item { get; set; }
    }
}
