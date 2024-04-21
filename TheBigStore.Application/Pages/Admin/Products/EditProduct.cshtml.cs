using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.ObjectModel;
using TheBigStore.Repository.Extensions;
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
        public List<CategoryDto>? Categories { get; set; }
        public string SuccessMessage { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;

        public async Task OnGetAsync(int id)
        {
            Item = await _itemService.GetByIdAsync(id);
            if (Item.CategoryId != null)
                Category = await _categoryService.GetByIdAsync((int)Item.CategoryId);

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
                try
                {
                    Item.ItemName.FirstCharToUpper();
                    Item.Description.FirstCharToUpper();
                    await _itemService.UpdateAsync(Item);
                    SuccessMessage = "Product updated successfully";
                }
                catch (Exception e)
                {
                    ErrorMessage = e.Message;
                }
            }
            return RedirectToPage();
        }


    }
}
