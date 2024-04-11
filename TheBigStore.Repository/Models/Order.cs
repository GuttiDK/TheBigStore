using System.ComponentModel.DataAnnotations;
using TheBigStore.Repository.Enums;

namespace TheBigStore.Repository.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public OrderStatusEnum Status { get; set; }
        public List<ItemOrder>? ItemOrders { get; set; }
    }
}
