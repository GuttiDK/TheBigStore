using TheBigStore.Service.Enums;

namespace TheBigStore.Service.DataTransferObjects
{
    public class ItemOrderDto
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int OrderId { get; set; }

        public int Quantity { get; set; }
        public OrderStatusEnumDto Status { get; set; }

        // Navigation properties
        public OrderDto Order { get; set; }
        public ItemDto Item { get; set; }
    }
}
