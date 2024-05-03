using System.Net.Http.Json;
using TheBigStore.Blazor.Models;
using TheBigStore.Blazor.Service.Interfaces;

namespace TheBigStore.Blazor.Service.Services
{
    public class ItemOrderService : IItemOrderService
    {

        private readonly HttpClient _client;

        public ItemOrderService(HttpClient client)
        {
            _client = client;
        }

        public async Task<HttpContent> CreateItemOrders(List<ItemOrder> ItemOrders)
        {
            var response = await _client.PostAsJsonAsync("/api/itemorder/create", ItemOrders);

            return response.Content;
        }


    }
}
