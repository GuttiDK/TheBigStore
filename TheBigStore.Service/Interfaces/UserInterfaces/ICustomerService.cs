using TheBigStore.Repository.Models;
using TheBigStore.Service.DataTransferObjects;
using TheBigStore.Service.Interfaces.GenericInterfaces;

namespace TheBigStore.Service.Interfaces.UserInterfaces
{
    public interface ICustomerService : IGenericService<CustomerDto>
    {

        /// <summary>
        /// Add items to the cart
        /// </summary>
        /// <param name="address"></param>
        /// <param name="customer"></param>
        /// <param name="items"></param>
        /// <param name="userId"></param>
        Task AddToCart(List<ItemDto> items, int userId, CustomerDto customer, AddressDto address);
    }
}
