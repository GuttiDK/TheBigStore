namespace TheBigStore.Service.DataTransferObjects
{
    public class CategoryDto
    {
        public int Id { get; set; }
        // CategoryName
        public string CategoryName { get; set; } = string.Empty;
        public List<ItemDto> Items { get; set; } = [];
    }
}
