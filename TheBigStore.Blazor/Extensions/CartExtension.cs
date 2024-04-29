using TheBigStore.Blazor.Service.Intefaces;
using TheBigStore.Blazor.Utility;
using TheBigStore.Blazor.Models;

namespace TheBigStore.Blazor.Extensions
{
    public static class CartExtension
    {
        public static int CartCount { get; set; } = 0;


        public static async Task AddToCart(LocalStorage localStorage, IItemService itemService, int itemId)
        {

            var product = await itemService.GetItemByIdAsync(itemId);
            product.Category = null;
            product.Image = null;

            var cart = await localStorage.Get<List<Item>>("cart") ?? new List<Item>();

            var existingProduct = cart.FirstOrDefault(wi => wi.Id == itemId);
            if (existingProduct != null)
            {
                // If the product already exists, increase its quantity
                existingProduct.Quantity++;
            }
            else
            {
                // If the product doesn't exist, add it to the cart
                product.Quantity = 1; // Initialize quantity to 1
                cart.Add(product);
            }

            CartCount = cart.Sum(wi => wi.Quantity);
            await localStorage.Set("cart", cart);
        }
    }
}

