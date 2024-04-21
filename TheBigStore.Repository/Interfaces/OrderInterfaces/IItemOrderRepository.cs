using TheBigStore.Repository.Interfaces.GenericInterfaces;
using TheBigStore.Repository.Models;

namespace TheBigStore.Repository.Interfaces.OrderInterfaces
{
    public interface IItemOrderRepository : IGenericRepository<ItemOrder>
    {

        /// <summary>
        /// Get all item orders by order id
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<List<ItemOrder>> GetAllByOrderId(int orderId);
    }
}
