using TheBigStore.Service.Enums;

namespace TheBigStore.Service.DataTransferObjects
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public CustomerDto Customer { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public DateTime DeliveryDate { get; set; } = DateTime.Now.AddDays(7);
        public OrderStatusEnumDto Status { get; set; } = OrderStatusEnumDto.Pending;
        public List<ItemOrderDto> ItemOrders { get; set; } = [];
    }
}
