using System.Net.Http.Json;
using TheBigStore.Blazor.Models;
using TheBigStore.Blazor.Service.Interfaces;

namespace TheBigStore.Blazor.Service.Services
{
    public class CustomerService : ICustomerService
    {

        private readonly HttpClient _client;

        public CustomerService(HttpClient client)
        {
            _client = client;
        }

        public async Task<Customer> CreateCustomer(Customer Customer)
        {
            var response = await _client.PostAsJsonAsync("/api/customer/create", Customer);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<Customer>();
        }


    }
}
