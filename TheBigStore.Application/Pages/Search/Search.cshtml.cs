using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis;
using System.Collections.ObjectModel;
using TheBigStore.Application.SessionHelper;
using TheBigStore.Repository.Models;
using TheBigStore.Service.DataTransferObjects;
using TheBigStore.Service.Interfaces.OrderInterfaces;
using TheBigStore.Service.Services.OrderServices;

namespace TheBigStore.Application.Pages.Search
{
    public class SearchModel : PageModel
    {
        private readonly IItemService _itemService;
        private readonly IImageService _imageService;

        public SearchModel(IItemService itemService, IImageService imageService)
        {
            _itemService = itemService;
            _imageService=imageService;
        }

        public List<ItemDto> FindProducts { get; set; }
        public List<ImageDto> Images { get; set; }
        [BindProperty(SupportsGet = true)]
        public int productId { get; set; }

        public async Task OnGetAsync(string SearchWord)
        {
            FindProducts = await _itemService.SearchProductByWord(SearchWord);
            Images = await _imageService.GetAllAsync();

            foreach (var item in FindProducts)
            {
                item.Image = Images.SingleOrDefault(x => x.Id == item.ImageId);
            }
        }

        public async Task<IActionResult> OnPostAddToCart() // Method to handle adding product to cart
        {
            var product = await _itemService.GetByIdAsync(productId);

            // Retrieve cart from session
            var cart = HttpContext.Session.Get<List<ItemDto>>("Cart") ?? new List<ItemDto>();

            // Check if the product already exists in the cart
            var existingItem = cart.FirstOrDefault(item => item.Id == product.Id);

            if (existingItem != null)
            {
                // If the product already exists, increase its quantity
                existingItem.Quantity++;
            }
            else
            {
                // If the product doesn't exist, add it to the cart
                product.Quantity = 1; // Initialize quantity to 1
                cart.Add(product);
            }

            // Update cart in session
            HttpContext.Session.Set("Cart", cart);

            // Redirect to checkout page
            return RedirectToPage("/Customer/Orders/Checkout");
        }
    }
}
