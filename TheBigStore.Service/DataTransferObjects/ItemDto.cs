namespace TheBigStore.Service.DataTransferObjects
{
    public class ItemDto
    {

        public int Id { get; set; }

        // Item
        public string ItemName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0;
        public int Stock { get; set; } = 0;

        // ItemOrder
        public List<ItemOrderDto> ItemOrders { get; set; } = [];

        // Category
        public int? CategoryId { get; set; }
        public CategoryDto? Category { get; set; }

        // Image
        public int? ImageId { get; set; } // FK
        public ImageDto? Image { get; set; }
        public int? Quantity { get; set; }
    }
}
