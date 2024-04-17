using System.Collections.ObjectModel;
using TheBigStore.Repository.Interfaces.OrderInterfaces;
using TheBigStore.Repository.Models;
using TheBigStore.Service.DataTransferObjects;
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

    }
}
