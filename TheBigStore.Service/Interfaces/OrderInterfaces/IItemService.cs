using TheBigStore.Service.DataTransferObjects;
using TheBigStore.Service.Interfaces.GenericInterfaces;

namespace TheBigStore.Service.Interfaces.OrderInterfaces
{
    public interface IItemService : IGenericService<ItemDto>
    {
        Task<List<ItemDto>> SearchProductByWord(string word);
        Task<List<CategoryDto>> GetAllCategories();
    }
}
