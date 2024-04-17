using TheBigStore.Repository.Interfaces.GenericInterfaces;
using TheBigStore.Repository.Models;

namespace TheBigStore.Repository.Interfaces.UserInterfaces
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        /// <summary>
        /// Add items to the cart
        /// </summary>
        /// <param name="address"></param>
        /// <param name="customer"></param>
        /// <param name="items"></param>
        /// <param name="userId"></param>
        Task AddToCart(List<Item> items, int userId, Customer customer, Address address);
    }
}