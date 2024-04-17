using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheBigStore.Repository.Extensions;
using TheBigStore.Repository.Models;
using TheBigStore.Service.DataTransferObjects;
using TheBigStore.Service.Interfaces.OrderInterfaces;

namespace TheBigStore.Application.Pages.Admin.Products
{
    public class EditCategoryModel : PageModel
    {
        private readonly ICategoryService _categoryService;
        public EditCategoryModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [BindProperty]
        public CategoryDto Category { get; set; }
        public string SuccessMessage { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;

        public async Task OnGetAsync(int id)
        {
            CategoryDto category = await _categoryService.GetById(id);

            if (category != null)
            {
                Category = category;
            }
        }

        public async Task<IActionResult> OnPostUpdateCategory()
        {
            if (ModelState.IsValid)
            {
                var dto = await _categoryService.GetById(Category.Id);
                if (dto != null)
                {
                    dto.Id = Category.Id;
                    dto.CategoryName = Category.CategoryName.FirstCharToUpper();
                    await _categoryService.UpdateAsync(dto);
                    SuccessMessage = "Category updated successfully";
                }
                else
                {
                    ErrorMessage = "Category not found";
                }
            }

            return Page();

        }
    }
}
