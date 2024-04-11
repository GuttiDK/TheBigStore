using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TheBigStore.Application.Pages.Products
{
    public class ProductsModel : PageModel
    {
        private readonly ILogger<ProductsModel> _logger;

        public ProductsModel(ILogger<ProductsModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
