using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using TheBigStore.Service.DataTransferObjects;
using TheBigStore.Service.Interfaces.OrderInterfaces;

namespace TheBigStore.WebAPI.Controllers.OrdersControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService=orderService;
        }


        /// <summary>
        /// Get a list of all orders in DB.
        /// </summary>
        /// <returns>List of orders.</returns>
        [HttpGet]
        public async Task<List<OrderDto>> GetAllOrders()
        {
            return await _orderService.GetAllAsync();
        }
    }
}
