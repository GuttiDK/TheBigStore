using TheBigStore.Repository.Interfaces.OrderInterfaces;
using TheBigStore.Repository.Models;
using TheBigStore.Service.DataTransferObjects;
using TheBigStore.Service.Interfaces.OrderInterfaces;
using TheBigStore.Service.Services.GenericServices;
using TheBigStore.Service.Services.MappingServices;

namespace TheBigStore.Service.Services.OrderServices
{
    public class OrderService : GenericService<OrderDto, IOrderRepository, Order>, IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly MappingService _mappingService;

        public OrderService(MappingService mappingService, IOrderRepository orderRepository) : base(mappingService, orderRepository)
        {
            _orderRepository = orderRepository;
            _mappingService = mappingService;
        }
    }
}
