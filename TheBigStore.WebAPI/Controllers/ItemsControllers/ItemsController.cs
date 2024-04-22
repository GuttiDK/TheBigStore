using Microsoft.AspNetCore.Mvc;
using TheBigStore.Service.DataTransferObjects;
using TheBigStore.Service.Interfaces.OrderInterfaces;

namespace TheBigStore.WebAPI.Controllers.ItemsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ItemsController : ControllerBase
    {
        #region
        private readonly IItemService _itemService;
        private readonly ILogger<ItemsController> _logger;
        #endregion

        #region Constructor
        public ItemsController(IItemService itemService, ILogger<ItemsController> logger)
        {
            _itemService = itemService;
            _logger = logger;
        }
        #endregion


        [HttpGet]
        [Route("get")]
        public async Task<IEnumerable<ItemDto>> Get()
        {
            return await _itemService.GetAllAsync();
        }

        // Get GetPagnatedList of users with int for page and int count for page size
        [HttpGet]
        [Route("getpagnatedlist")]
        public async Task<IActionResult> GetPagnatedList(int page, int count)
        {
            var temp = await _itemService.GetPagnatedList(page, count);

            if (temp != null)
            {
                return Ok(temp);
            }

            return BadRequest();
        }
    }
}
