using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using TheBigStore.Repository.Extensions;
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
        [Route("get")]
        public async Task<IEnumerable<OrderDto>> Get()
        {
            return await _orderService.GetAllAsync();
        }

        // Get GetPagnatedList of users with int for page and int count for page size
        [HttpGet]
        [Route("getpagnatedlist")]
        public async Task<IActionResult> GetPagnatedList(int page, int count)
        {
            PageOptions options = new()
            {
                CurrentPage = page,
                PageSize = count
            };
            var temp = await _orderService.GetPagnatedList(options);

            if (temp != null)
            {
                return Ok(temp);
            }

            return BadRequest();
        }
    }
}
