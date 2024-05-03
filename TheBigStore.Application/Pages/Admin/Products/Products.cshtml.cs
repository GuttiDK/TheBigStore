using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.ObjectModel;
using TheBigStore.Repository.Extensions;
using TheBigStore.Service.DataTransferObjects;
using TheBigStore.Service.Interfaces.OrderInterfaces;

namespace TheBigStore.Application.Pages.Products
{
    public class ProductsModel : PageModel
    {
        private readonly IItemService _itemService;
        private readonly ICategoryService _categoryService;
        private readonly IItemOrderService _itemOrderService;

        public ProductsModel(IItemService itemService, ICategoryService categoryService, IItemOrderService itemOrderService)
        {
            _itemService=itemService;
            _categoryService=categoryService;
            _itemOrderService=itemOrderService;
        }

        [BindProperty]
        public List<ItemDto>? Items { get; set; }
        public List<CategoryDto>? Categories { get; set; }
        [BindProperty]
        public ItemDto Item { get; set; }

        public string SuccessMessage { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;

        public async Task<IActionResult> OnGetAsync()
        {
            Items = await _itemService.GetAllAsync();
            Categories = await _categoryService.GetAllAsync();
            foreach (var item in Items)
            {
                item.Category = Categories.FirstOrDefault(x => x.Id == item.CategoryId);
            }


            return Page();
        }

        public async Task<IActionResult> OnPostCreateItem()
        {
            if (Item.ItemName != null)
            {
                ItemDto itemDto = new()
                {
                    ItemName = Item.ItemName.FirstCharToUpper(),
                    Description = Item.Description.FirstCharToUpper(),
                    Price = Item.Price,
                    Stock = Item.Stock,
                    CategoryId = Item.CategoryId,
                };

                await _itemService.CreateAsync(itemDto);
            }
            else
            {
                ErrorMessage = "Item name is required";
                return Page();
            }



            return RedirectToPage("/Admin/Products/Products");
        }

        public async Task<IActionResult> OnPostDeleteItem(int id)
        {
            var item = await _itemService.GetByIdAsync(id);
            await _itemService.DeleteAsync(item);
            return RedirectToPage("/Admin/Products/Products");
        }
    }
}
