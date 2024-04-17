using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.ObjectModel;
using TheBigStore.Repository.Models;
using TheBigStore.Service.DataTransferObjects;
using TheBigStore.Service.Interfaces.OrderInterfaces;
using TheBigStore.Service.Services.OrderServices;

namespace TheBigStore.Application.Pages.Search
{
    public class SearchModel : PageModel
    {
        private readonly IItemService _services;
        private readonly IImageService _imageService;

        public SearchModel(IItemService services, IImageService imageService)
        {
            _services = services;
            _imageService=imageService;
        }

        public List<ItemDto> FindProducts { get; set; }
        public ObservableCollection<ImageDto> Images { get; set; }

        public async Task OnGetAsync(string SearchWord)
        {
            FindProducts = await _services.SearchProductByWord(SearchWord);
            Images = await _imageService.GetAllAsync();

            foreach (var item in FindProducts)
            {
                item.Image = Images.SingleOrDefault(x => x.ImageId == item.ImageId);
            }
        }
    }
}
