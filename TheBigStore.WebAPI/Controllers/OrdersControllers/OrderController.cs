using Microsoft.AspNetCore.Mvc;
using TheBigStore.Service.DataTransferObjects;
using TheBigStore.Service.Interfaces.OrderInterfaces;

namespace TheBigStore.WebAPI.Controllers.OrdersControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService=orderService;
        }

        /// <summary>
        /// Create new Order. ( Under Development )  
        /// </summary>
        /// <param name="orderDTO"></param>
        /// /// <remarks>
        /// Sample request:
        ///
        ///
        /// </remarks>
        [HttpPost]
        public async Task CreateNewOrder(OrderDto orderDTO)
        {
            await _orderService.CreateAsync(orderDTO);
        }
    }
}
