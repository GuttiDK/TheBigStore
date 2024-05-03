using TheBigStore.Repository.Enums;

namespace TheBigStore.WebAPI.Models
{
    public class OrderModel
    {
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public OrderStatusEnum Status { get; set; }

    }
}
