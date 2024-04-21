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

        // Get GetPagnatedList of users with int for page and int count for page size
        [HttpGet(Name = "GetPagnatedList")]
        [Route("GetPagnatedList")]
        public async Task<IActionResult> GetPagnatedList(int page, int count)
        {
            var temp = await _orderService.GetPagnatedList(page, count);

            if (temp != null)
            {
                return Ok(temp);
            }

            return BadRequest();
        }
    }
}
