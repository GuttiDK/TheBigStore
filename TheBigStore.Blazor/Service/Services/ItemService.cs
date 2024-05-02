using TheBigStore.Blazor.Models;
using TheBigStore.Blazor.Service.Intefaces;
using System.Net.Http.Json;
using Newtonsoft.Json;
using TheBigStore.Blazor.Extensions;
using Microsoft.AspNetCore.JsonPatch;

namespace TheBigStore.Blazor.Service.Services
{
    public class ItemService : IItemService
    {
        private readonly HttpClient _client;

        public ItemService(HttpClient client)
        {
            _client = client;
        }

        public async Task<Item> CreateItem(Item item)
        {
            var response = await _client.PostAsJsonAsync("api/item/create", item);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<Item>();
        }

        public async Task<List<Item>> GetFeaturedItemsAsync()
        {
            var Request = "/api/items/getfeatureditems";

            return await _client.GetFromJsonAsync<List<Item>>(Request);
        }

        public async Task<List<Item>> GetAllItemsByCategory(int categoryId)
        {
            var Request = $"/api/items/getitemsbycategory/{categoryId}";

            return await _client.GetFromJsonAsync<List<Item>>(Request);
        }

        public async Task<List<Item>> GetFeaturedItemsByCategoryAsync(int categoryId)
        {
            var Request = $"/api/items/getfeatureditemsbycategory/{categoryId}/1/8";

            return await _client.GetFromJsonAsync<List<Item>>(Request);
        }

        public async Task<Item> GetItemByIdAsync(int itemId)
        {
            var Request = $"/api/item/{itemId}";

            return await _client.GetFromJsonAsync<Item>(Request);
        }

        public async Task<Item> UpdateShopAsync(int itemId, Item newitem)
        {
            var oldItem = await GetItemByIdAsync(itemId);
            oldItem.Category = null;
            newitem.Category = null;

            JsonPatchDocument<Item> document = oldItem.PatchModel(newitem);

            StringContent stringContent = new(JsonConvert.SerializeObject(document), System.Text.Encoding.UTF8, "application/json-patch+json");

            var request = new HttpRequestMessage(HttpMethod.Patch, $"/item/update/{itemId}") { Content = stringContent };

            var response = await _client.SendAsync(request);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<Item>();
        }

        public async Task<bool> CheckStock(int itemId, int amount)
        {
            var Request = $"/api/item/checkstock/{itemId}/{amount}";

            return await _client.GetFromJsonAsync<bool>(Request);
        }

        // Update stock of an item with amount and id and return the item
        public async Task<Item> UpdateStock(int itemId, int amount)
        {
            var Request = $"/api/item/updatestock/{itemId}/{amount}";

            return await _client.GetFromJsonAsync<Item>(Request);
        }
    }
}
