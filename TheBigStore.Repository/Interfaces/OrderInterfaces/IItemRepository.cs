using TheBigStore.Repository.Extensions;
using TheBigStore.Repository.Interfaces.GenericInterfaces;
using TheBigStore.Repository.Models;
using TheBigStore.Repository.Models.Paging;

namespace TheBigStore.Repository.Interfaces.OrderInterfaces
{
    public interface IItemRepository : IGenericRepository<Item>
    {
        /// <summary>
        /// Search for a product by word
        /// </summary>
        /// <param name="word"></param>
        /// <returns>List of items with the word</returns>
        Task<List<Item>> SearchProductByWord(string word);

        /// <summary>
        /// Gets all categories
        /// </summary>
        /// <returns>List of all categories</returns>
        Task<List<Category>> GetAllCategories();

        Task<Page<Item>> GetItemsbyCategory(int categoryId, PageOptions options);

        Task<bool> CheckStock(int id, int amount);

        Task<Item> UpdateStock(int id, int amount);
    }
}
