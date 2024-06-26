﻿using TheBigStore.Repository.Enums;

namespace TheBigStore.Service.DataTransferObjects
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }

        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; } 
        public OrderStatusEnum Status { get; set; }

        // Navigation properties
        public List<ItemOrderDto>? ItemOrders { get; set; }
        public CustomerDto Customer { get; set; }
    }
}
