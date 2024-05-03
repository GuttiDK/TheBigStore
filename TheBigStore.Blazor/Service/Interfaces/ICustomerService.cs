using TheBigStore.Blazor.Models;

namespace TheBigStore.Blazor.Service.Interfaces
{
    public interface ICustomerService
    {
        /// <summary>
        /// Creates a new customer
        /// </summary>
        /// <param name="Customer"></param>
        /// <returns></returns>
        public Task<Customer> CreateCustomer(Customer Customer);
    }
}
