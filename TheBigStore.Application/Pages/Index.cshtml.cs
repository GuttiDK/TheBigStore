using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheBigStore.Application.SessionHelper;
using TheBigStore.Repository.Extensions;
using TheBigStore.Service.DataTransferObjects;
using TheBigStore.Service.DataTransferObjects.Paging;
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
            PageOptions options = new()
            {
                CurrentPage = page,
                PageSize = count
            };
            Items = await _itemService.GetPagnatedList(options);
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
            product.Category = null;
            product.Image = null;

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


