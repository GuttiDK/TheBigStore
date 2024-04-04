﻿using System.ComponentModel.DataAnnotations;
using TheBigStore.Repository.Enums;

namespace TheBigStore.Repository.Models
{
    public class ItemOrder
    {
        [Key]
        public int Id { get; set; }

        public int Quantity { get; set; } = 0;
        public OrderStatusEnum Status { get; set; } = OrderStatusEnum.Pending;

        public int ItemId { get; set; }
        public Item Item { get; set; } = new Item();
        public int OrderId { get; set; }
        public Order Order { get; set; } = new Order();
    }
}