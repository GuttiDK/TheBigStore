using TheBigStore.Service.DataTransferObjects;
using TheBigStore.Service.Interfaces.GenericInterfaces;

namespace TheBigStore.Service.Interfaces.OrderInterfaces
{
    public interface IItemOrderService : IGenericService<ItemOrderDto>
    {

        /// <summary>
        /// Get all item orders by order id
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<List<ItemOrderDto>> GetAllByOrderId(int orderId);
    }
}
