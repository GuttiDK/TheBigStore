using Microsoft.AspNetCore.Mvc;
using TheBigStore.Repository.Extensions;
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

        /// <summary>
        /// Get List of all products in DB.
        /// </summary>
        /// <returns>Product Object</returns>
        [HttpGet]
        [Route("getpagnatedlist")]
        public async Task<IActionResult> GetPagnatedList(int page, int count)
        {
            PageOptions options = new()
            {
                CurrentPage = page,
                PageSize = count
            };
            var temp = await _itemService.GetPagnatedList(options);

            if (temp != null)
            {
                return Ok(temp);
            }

            return BadRequest();
        }

        /// <summary>
        /// Get a List of products by search title.
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns>list of products</returns>
        [HttpGet]
        [Route("search/{searchString}")]
        public async Task<IActionResult> SearchProducts(string searchString)
        {
            var temp = await _itemService.SearchProductByWord(searchString);

            if (temp != null)
            {
                return Ok(temp);
            }

            return NotFound();
        }
    }
}
