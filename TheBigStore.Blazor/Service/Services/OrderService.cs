using System.Net.Http.Json;
using TheBigStore.Blazor.Models;
using TheBigStore.Blazor.Service.Interfaces;

namespace TheBigStore.Blazor.Service.Services
{
    public class OrderService : IOrderService
    {

        private readonly HttpClient _client;

        public OrderService(HttpClient client)
        {
            _client = client;
        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            var Request = $"/api/order/{orderId}";

            return await _client.GetFromJsonAsync<Order>(Request);
        }

        public async Task<Order> CreateOrder(Order Order)
        {
            var response = await _client.PostAsJsonAsync("/api/order/create", Order);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<Order>();
        }


    }
}
