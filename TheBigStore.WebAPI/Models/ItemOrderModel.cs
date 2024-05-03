using TheBigStore.Repository.Enums;

namespace TheBigStore.WebAPI.Models
{
    public class ItemOrderModel
    {
        public int ItemId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public OrderStatusEnum Status { get; set; }
    }
}
