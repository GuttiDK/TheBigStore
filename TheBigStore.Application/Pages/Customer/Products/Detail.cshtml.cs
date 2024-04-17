using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheBigStore.Service.DataTransferObjects;
using TheBigStore.Service.Interfaces.OrderInterfaces;

namespace TheBigStore.Application.Pages.Customer.Products
{
    public class DetailModel : PageModel
    {
        [BindProperty]
        public ItemDto Product { get; set; }
        public CategoryDto Category { get; set; }
        public ImageDto Image { get; set; }

        private readonly IItemService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IImageService _imageService;

        public DetailModel(IItemService productService, ICategoryService categoryService, IImageService imageService)
        {
            _productService = productService;
            _categoryService=categoryService;
            _imageService=imageService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Product = await _productService.GetById(id);
            if (Product != null)
            {
                if (Product.CategoryId != null)
                {
                    Product.Category = await _categoryService.GetById((int)Product.CategoryId);
                }
                if (Product.ImageId != null)
                {
                    Product.Image = await _imageService.GetById((int)Product.ImageId);
                }
            }
            if (Product == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}