using TheBigStore.Repository.Models;
using TheBigStore.Service.DataTransferObjects;
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
