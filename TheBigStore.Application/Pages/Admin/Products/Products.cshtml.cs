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
        public ObservableCollection<ItemDto>? Items { get; set; }
        public ObservableCollection<CategoryDto>? Categories { get; set; }
        public ObservableCollection<ItemOrderDto>? ItemOrders { get; set; }
        [BindProperty]
        public ItemDto Item { get; set; }

        public string SuccessMessage { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;

        public async Task<IActionResult> OnGetAsync()
        {
            Items = await _itemService.GetAllAsync();
            Categories = await _categoryService.GetAllAsync();
            ItemOrders = await _itemOrderService.GetAllAsync();
            foreach (var item in Items)
            {
                item.Category = Categories.FirstOrDefault(x => x.Id == item.CategoryId);
                item.ItemOrders = ItemOrders.Where(x => x.ItemId == item.Id).ToList();
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
            var item = await _itemService.GetById(id);
            await _itemService.DeleteAsync(item);
            return RedirectToPage("/Admin/Products/Products");
        }
    }
}
