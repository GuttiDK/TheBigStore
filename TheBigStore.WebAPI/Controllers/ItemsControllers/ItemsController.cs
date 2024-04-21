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
        public async Task<IEnumerable<ItemDto>> Get()
        {
            return await _itemService.GetAllAsync();
        }
    }
}
