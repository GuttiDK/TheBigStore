using System.ComponentModel.DataAnnotations;
using TheBigStore.Repository.Enums;

namespace TheBigStore.Repository.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = new Customer();
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public DateTime DeliveryDate { get; set; } = DateTime.Now.AddDays(7);
        public OrderStatusEnum Status { get; set; } = OrderStatusEnum.Pending;
        public List<ItemOrder> ItemOrders { get; set; } = [];
    }
}
