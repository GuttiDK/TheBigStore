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
        #region
        private readonly IOrderService _orderService;
        private readonly ILogger<OrdersController> _logger;
        #endregion

        #region Constructor
        public OrdersController(IOrderService orderService, ILogger<OrdersController> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }
        #endregion

        [HttpGet]
        public async Task<IEnumerable<OrderDto>> Get()
        {
            return await _orderService.GetAllAsync();
        }
    }
}
