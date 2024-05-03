using Microsoft.AspNetCore.Mvc;
using TheBigStore.Service.Interfaces.OrderInterfaces;

namespace TheBigStore.WebAPI.Controllers.ItemOrdersControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ItemOrdersController : ControllerBase
    {
        #region
        private readonly IItemOrderService _itemOrderService;
        private readonly ILogger<ItemOrderController> _logger;
        #endregion

        #region Constructor
        public ItemOrdersController(IItemOrderService itemOrderService, ILogger<ItemOrderController> logger)
        {
            _itemOrderService = itemOrderService;
            _logger = logger;
        }
        #endregion


        // Get GetPagnatedList of users with int for page and int count for page size
        [HttpGet]
        [Route("getpagnatedlist")]
        public async Task<IActionResult> GetPagnatedList(int page, int count)
        {
            var temp = await _itemOrderService.GetPagnatedList(page, count);

            if (temp != null)
            {
                return Ok(temp);
            }

            return BadRequest();
        }
    }
}
