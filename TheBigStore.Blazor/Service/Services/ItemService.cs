using TheBigStore.Blazor.Models;
using TheBigStore.Blazor.Service.Intefaces;
using System.Net.Http.Json;

namespace TheBigStore.Blazor.Service.Services
{
    public class ItemService : IItemService
    {
        private readonly HttpClient _client;

        public ItemService(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<Item>> GetFeaturedItemsAsync()
        {
            var Request = "/Items/GetFeaturedItems";

            return await _client.GetFromJsonAsync<List<Item>>(Request);
        }

        public async Task<List<Item>> GetAllItemsByCategory(int categoryId)
        {
            var Request = $"/Items/GetItemsByCategory/{categoryId}";

            return await _client.GetFromJsonAsync<List<Item>>(Request);
        }

        public async Task<List<Item>> GetFeaturedItemsByCategoryAsync(int categoryId)
        {
            var Request = $"/Items/GetFeaturedItemsByCategory/{categoryId}/1/8";
            //var Request = $"/Items/GetFeaturedItemsByCategory/1/1/8";

            return await _client.GetFromJsonAsync<List<Item>>(Request);
        }

        public async Task<Item> GetItemByIdAsync(int itemId)
        {
            var Request = $"/Item/{itemId}";

            return await _client.GetFromJsonAsync<Item>(Request);
        }
    }
}
