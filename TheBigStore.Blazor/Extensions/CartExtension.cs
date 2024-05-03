using TheBigStore.Blazor.Service.Interfaces;
using TheBigStore.Blazor.Utility;
using TheBigStore.Blazor.Models;
using System.Text.Json;
using TheBigStore.Blazor.Pages;

namespace TheBigStore.Blazor.Extensions
{
    public static class CartExtension
    {
        public static int CartCount { get; set; } = 0;

        public static async Task UpdateCartCount(LocalStorage _localStorage)
        {
            string? storage = await _localStorage.GetValueAsync<string>("Cart");

            if (storage != null)
            {
                var storedValue = JsonSerializer.Deserialize<List<Item>>(storage);
                CartCount = storedValue.Sum(wi => wi.Quantity);
            }
            else
            {
                CartCount = 0;
            }
        }

        public static async Task AddToCart(LocalStorage localStorage, IItemService itemService, int itemId)
        {
            var product = await itemService.GetItemByIdAsync(itemId);

            string? storage = await localStorage.GetValueAsync<string>("Cart");
            List<Item> ordredItems = new();

            if (storage == null)
            {
                product.Quantity = 1;
                ordredItems.Add(product);
                CartCount = ordredItems.Sum(wi => wi.Quantity);
                string serializedItems = JsonSerializer.Serialize(ordredItems);
                await localStorage.SetValueAsync("Cart", serializedItems);
            } // If cookie exists
            else
            {
                ordredItems = JsonSerializer.Deserialize<List<Item>>(storage);

                // Check if the item is already in the cart
                if (ordredItems.Where(wp => wp.Id == itemId).Any())
                {
                    ordredItems.Single(wp => wp.Id == itemId).Quantity++;
                } // Else add it to the cart
                else
                {
                    product.Quantity = 1;
                    ordredItems.Add(product);
                }

                await UpdateCartCount(localStorage);
                string serializedItems = JsonSerializer.Serialize(ordredItems);
                await localStorage.SetValueAsync("Cart", serializedItems);
            }
        }
    }
}
