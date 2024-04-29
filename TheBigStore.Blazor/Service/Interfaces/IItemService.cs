using TheBigStore.Blazor.Models;

namespace TheBigStore.Blazor.Service.Intefaces
{
    public interface IItemService
    {
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
    }
}
