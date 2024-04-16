using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.ObjectModel;
using TheBigStore.Repository.Models;
using TheBigStore.Service.DataTransferObjects;
using TheBigStore.Service.Interfaces.OrderInterfaces;
using TheBigStore.Service.Services.OrderServices;

namespace TheBigStore.Application.Pages.Admin.Products
{
    public class EditProductModel : PageModel
    {
        private readonly IItemService _itemService;
        private readonly ICategoryService _categoryService;
        public EditProductModel(IItemService itemService, ICategoryService categoryService)
        {
            _itemService=itemService;
            _categoryService=categoryService;
        }

        [BindProperty]
        public ItemDto Item { get; set; }
        public CategoryDto Category { get; set; }
        public ObservableCollection<CategoryDto>? Categories { get; set; }
        public string SuccessMessage { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;

        public async Task OnGetAsync(int id)
        {
            Item = await _itemService.GetById(id);
            if (Item.CategoryId != null)
                Category = await _categoryService.GetById((int)Item.CategoryId);

            Categories = await _categoryService.GetAllAsync();

            var test = Categories.SingleOrDefault(x => x.Id == Item.CategoryId);
            if (Item.CategoryId != null && test != null)
            {
                Categories.Remove(test);
            }
        }

        public async Task<IActionResult> OnPostUpdateProduct()
        {
            if (ModelState.IsValid)
            {
                var result = await _itemService.GetById(Item.Id);
                if (result != null)
                {
                    result.Id = Item.Id;
                    result.ItemName = Item.ItemName;
                    result.Description = Item.Description;
                    result.Price = Item.Price;
                    result.CategoryId = Item.CategoryId;
                    result.Stock = Item.Stock;
                    await _itemService.UpdateAsync(result);
                    SuccessMessage = "Product updated successfully";
                    return RedirectToPage($@"/Admin/Products/Products");
                }
                else
                {
                    ErrorMessage = "Product not found";
                    return Page();
                }
            }

            return Page();
        }

    }
}
