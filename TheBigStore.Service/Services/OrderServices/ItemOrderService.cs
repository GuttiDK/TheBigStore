using TheBigStore.Repository.Interfaces.OrderInterfaces;
using TheBigStore.Repository.Models;
using TheBigStore.Repository.Repositories.OrderRepositories;
using TheBigStore.Service.DataTransferObjects;
using TheBigStore.Service.Interfaces.OrderInterfaces;
using TheBigStore.Service.Services.GenericServices;
using TheBigStore.Service.Services.MappingServices;

namespace TheBigStore.Service.Services.OrderServices
{
    public class ItemOrderService : GenericService<ItemOrderDto, IItemOrderRepository, ItemOrder>, IItemOrderService
    {
        private readonly IItemOrderRepository _itemOrderRepository;
        private readonly MappingService _mappingService;
        public ItemOrderService(MappingService mappingService, IItemOrderRepository itemOrderRepository) : base(mappingService, itemOrderRepository)
        {
            _itemOrderRepository = itemOrderRepository;
            _mappingService = mappingService;
        }

        public async Task<List<ItemOrderDto>> GetAllByOrderId(int orderId)
        {
            var temp = _mappingService._mapper.Map<List<ItemOrderDto>>(await _itemOrderRepository.GetAllByOrderId(orderId));
            return temp;
        }
    }
}
