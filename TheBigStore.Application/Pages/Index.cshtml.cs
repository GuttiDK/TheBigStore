using MailKit.Search;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using TheBigStore.Application.SessionHelper;
using TheBigStore.Repository.Extensions.Paging;
using TheBigStore.Service.DataTransferObjects;
using TheBigStore.Service.Extensions.Paging;
using TheBigStore.Service.Interfaces.OrderInterfaces;
using TheBigStore.Service.Interfaces.UserInterfaces;

namespace TheBigStore.Application.Pages
{

    public class IndexModel : PageModel
    {
        private readonly IItemService _itemService;
        private readonly IImageService _imageService;
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;
        public IndexModel(IItemService itemService, IImageService imageService, IOrderService orderService)
        {
            _itemService = itemService;
            _imageService=imageService;
            _orderService=orderService;
        }

        public PageDto<ItemDto> Items { get; set; }
        public List<ImageDto> Images { get; set; }

        [BindProperty(SupportsGet = true)]
        public int productId { get; set; }

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; }

        [BindProperty(SupportsGet = true)]
        public int PageSize { get; set; }

        public async Task OnGetAsync(int page = 1, int count = 8)
        {
            Items = await _itemService.GetPagnatedList(page, count);
            Images = await _imageService.GetAllAsync();

            foreach (var item in Items.Items)
            {
                item.Image = Images.SingleOrDefault(x => x.Id == item.ImageId);
            }
        }

        public IActionResult OnPostSearch()
        {
            return RedirectToPage("/Index", new { page = CurrentPage, count = PageSize });
        }

        public async Task<IActionResult> OnPostAddToCart() // Method to handle adding product to cart
        {
            var product = await _itemService.GetByIdAsync(productId);

            // Retrieve cart from session
            var cart = HttpContext.Session.Get<List<ItemDto>>("cart") ?? new List<ItemDto>();

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
            HttpContext.Session.Set("cart", cart);

            // Redirect to checkout page
            return RedirectToPage("/Customer/Orders/Checkout");
        }

    }
}


