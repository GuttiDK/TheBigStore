using TheBigStore.Repository.Enums;
using TheBigStore.Repository.Extensions;
using TheBigStore.Service.DataTransferObjects;
using TheBigStore.Service.DataTransferObjects.Paging;
using TheBigStore.Service.Interfaces.GenericInterfaces;

namespace TheBigStore.Service.Interfaces.OrderInterfaces
{
    public interface IItemService : IGenericService<ItemDto>
    {
        /// <summary>
        /// Search for a product by word
        /// </summary>
        /// <param name="word"></param>
        /// <returns>List of items with the word</returns>
        Task<List<ItemDto>> SearchProductByWord(string word);

        /// <summary>
        /// Gets all categories
        /// </summary>
        /// <returns>Returns categories</returns>
        Task<List<CategoryDto>> GetAllCategories();
        Task<List<ItemDto>> GetItemsByCategory(int categoryId);
        Task<PageDto<ItemDto>> GetItemsByCategory(string category, PageOptions options);
        Task<List<ItemDto>> GetItemsByCategory(int categoryId, PageOptions options);
        Task<PageDto<ItemDto>> GetItemsByCategory(int categoryId, PageOptions options, OrderByOptionsItem orderBy);

        Task<bool> CheckStock(int id, int amount);

        Task<ItemDto> UpdateStock(int id, int amount);
    }
}
