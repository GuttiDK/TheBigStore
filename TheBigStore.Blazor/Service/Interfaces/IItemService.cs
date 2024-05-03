using TheBigStore.Blazor.Models;
using TheBigStore.Blazor.Models.Paging;

namespace TheBigStore.Blazor.Service.Interfaces
{
    public interface IItemService
    {

        Task<bool> CheckStock(int itemId, int amount);

        Task<Item> UpdateStock(int itemId, int amount);

        Task<Item> CreateItem(Item item);

        Task<Item> UpdateShopAsync(int itemId, Item newitem);

        /// <summary>
        /// Get all items
        /// </summary>
        /// <returns></returns>
        public Task<List<Item>> GetFeaturedItemsAsync();

        /// <summary>
        /// Get all items
        /// </summary>
        /// <returns></returns>
        public Task<List<Item>> GetAllItemsByCategory(int categoryId);

        /// <summary>
        /// Get item by id
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public Task<Item> GetItemByIdAsync(int itemId);

        /// <summary>
        /// Get featured items by category
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public Task<List<Item>> GetFeaturedItemsByCategoryAsync(int categoryId);

        /// <summary>
        /// Delete an item
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public Task DeleteItem(int itemId);

        /// <summary>
        /// Get all items
        /// </summary>
        /// <returns></returns>
        public Task<List<Item>> GetAllItems();

    }
}
