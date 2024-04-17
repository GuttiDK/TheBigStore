using TheBigStore.Repository.Interfaces.GenericInterfaces;
using TheBigStore.Repository.Models;

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

        /// <summary>
        /// Add a product to the cart
        /// </summary>
        /// <param name="address"></param>
        /// <param name="customer"></param>
        /// <param name="productId"></param>
        /// <param name="userId"></param>
        /// <exception cref="Exception">Thrown when user not found</exception>
        /// <returns>Returns nothing</returns>
        Task AddToCart(int productId, int userId, Customer customer, Address address);
    }
}
