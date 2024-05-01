using Microsoft.Extensions.Options;
using System.Collections.ObjectModel;
using TheBigStore.Repository.Extensions;
using TheBigStore.Repository.Interfaces.OrderInterfaces;
using TheBigStore.Repository.Models;
using TheBigStore.Repository.Repositories.OrderRepositories;
using TheBigStore.Service.DataTransferObjects;
using TheBigStore.Service.DataTransferObjects.Paging;
using TheBigStore.Service.Interfaces.OrderInterfaces;
using TheBigStore.Service.Services.GenericServices;
using TheBigStore.Service.Services.MappingServices;

namespace TheBigStore.Service.Services.OrderServices
{
    public class ItemService : GenericService<ItemDto, IItemRepository, Item>, IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly MappingService _mappingService;
        public ItemService(MappingService mappingService, IItemRepository itemRepository) : base(mappingService, itemRepository)
        {
            _itemRepository = itemRepository;
            _mappingService = mappingService;
        }

        public async Task<List<ItemDto>> SearchProductByWord(string word)
        {
            return _mappingService._mapper.Map<List<ItemDto>>(await _itemRepository.SearchProductByWord(word));
        }

        public async Task<List<CategoryDto>> GetAllCategories()
        {
            return _mappingService._mapper.Map<List<CategoryDto>>(await _itemRepository.GetAllCategories());
        }

        public async Task<PageDto<ItemDto>> GetItemsByCategory(int categoryId, PageOptions options)
        {
            var pageDto = new PageDto<ItemDto>();
            var pageEntity = await _itemRepository.GetItemsbyCategory(categoryId, options);
            pageDto.Total = pageEntity.Total;
            pageDto.CurrentPage = pageEntity.CurrentPage;
            pageDto.PageSize = pageEntity.PageSize;
            pageDto.Items = _mappingService._mapper.Map<List<ItemDto>>(pageEntity.Items);
            return pageDto;
        }

    }
}
