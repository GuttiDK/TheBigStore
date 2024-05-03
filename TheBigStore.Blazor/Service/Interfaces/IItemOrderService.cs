using TheBigStore.Blazor.Models;

namespace TheBigStore.Blazor.Service.Interfaces
{
    public interface IItemOrderService
    {
        /// <summary>
        /// Creates a new item order
        /// </summary>
        /// <param name="ItemOrders"></param>
        /// <returns></returns>
        public Task<HttpContent> CreateItemOrders(List<ItemOrder> ItemOrders);
    }
}
