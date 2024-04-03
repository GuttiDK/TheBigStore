using System.ComponentModel.DataAnnotations;
using TheBigStore.Repository.Enums;

namespace TheBigStore.Repository.Models
{
    public class ItemOrderDto
    {
        public int Id { get; set; }

        public int Quantity { get; set; } = 0;
        public OrderStatusEnum Status { get; set; } = OrderStatusEnum.Pending;

        public int ItemId { get; set; }
        public ItemDto Item { get; set; } = new ItemDto();
        public int OrderId { get; set; }
        public OrderDto Order { get; set; } = new OrderDto();
    }
}
