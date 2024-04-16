using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.ObjectModel;
using TheBigStore.Service.DataTransferObjects;
using TheBigStore.Service.Interfaces.OrderInterfaces;

namespace TheBigStore.Application.Pages.Products
{
    public class CategoryModel : PageModel
    {
        private readonly ICategoryService _categoryService;
        private readonly IItemService _itemService;
        public CategoryModel(ICategoryService categoryService, IItemService itemService)
        {
            _categoryService = categoryService;
            _itemService=itemService;
        }

        [BindProperty]
        public ObservableCollection<CategoryDto>? Categories { get; set; }
        public ObservableCollection<ItemDto>? Items { get; set; }
        [BindProperty]
        public CategoryDto Category { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Categories = await _categoryService.GetAllAsync();
            Items = await _itemService.GetAllAsync();
            foreach (var category in Categories)
            {
                category.Items = Items.Where(x => x.CategoryId == category.Id).ToList();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostCreateCategory()
        {
            if (ModelState.IsValid)
            {
                if (Category.CategoryName != null)
                {
                    CategoryDto categoryDto = new()
                    {
                        CategoryName = Category.CategoryName
                    };

                    await _categoryService.CreateAsync(categoryDto);
                }
            }

            return RedirectToPage("/Admin/Products/Category");
        }

        public async Task<IActionResult> OnPostDeleteCategory(int id)
        {
            var category = await _categoryService.GetById(id);
            await _categoryService.DeleteAsync(category);
            return RedirectToPage("/Admin/Products/Category");
        }
    }
}
