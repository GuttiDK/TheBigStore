using TheBigStore.Service.Enums;

namespace TheBigStore.Service.DataTransferObjects
{
    public class ItemOrderDto
    {
        public int Id { get; set; }

        public int Quantity { get; set; } = 0;
        public OrderStatusEnumDto Status { get; set; } = OrderStatusEnumDto.Pending;

        public int ItemId { get; set; }
        public ItemDto Item { get; set; }
        public int OrderId { get; set; }
        public OrderDto Order { get; set; }
    }
}
