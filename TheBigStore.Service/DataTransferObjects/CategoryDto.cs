namespace TheBigStore.Service.DataTransferObjects
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        // Navigation properties
        public List<ItemDto> Items { get; set; }
    }
}
