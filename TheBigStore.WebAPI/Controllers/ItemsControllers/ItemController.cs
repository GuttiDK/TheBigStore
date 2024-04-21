using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TheBigStore.Service.DataTransferObjects;
using TheBigStore.Service.Interfaces.OrderInterfaces;

namespace TheBigStore.WebAPI.Controllers.ItemsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ItemController : ControllerBase
    {
        #region
        private readonly IItemService _itemService;
        private readonly ILogger<ItemController> _logger;
        #endregion

        #region Constructor
        public ItemController(IItemService itemService, ILogger<ItemController> logger)
        {
            _itemService = itemService;
            _logger = logger;
        }
        #endregion


        [HttpGet("{id:int}", Name = "GetItem")]
        public async Task<IActionResult> GetItem(int id)
        {
            var temp = await _itemService.GetByIdAsync(id);

            if (temp != null)
            {
                return Ok(temp);
            }

            return NotFound();
        }


        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(ItemDto item)
        {
            try
            {
                item = await _itemService.CreateAsync(item);
                return CreatedAtAction("GetItem", new { itemId = item.Id }, item);
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpDelete("{id:int}")]
        [Route("remove")]
        public async Task<IActionResult> Remove(int id)
        {
            var item = await _itemService.GetByIdAsync(id);

            if (item == null)
                return NotFound();

            try
            {
                await _itemService.DeleteAsync(item);
                return NoContent(); // Success
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> Edit(ItemDto item)
        {
            try
            {
                await _itemService.UpdateAsync(item);
                return CreatedAtAction("GetItem", new { itemId = item.Id }, item);
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpPatch("{id:int}")]
        [Route("update")]
        public async Task<IActionResult> EditPartially(int id, [FromBody] JsonPatchDocument<ItemDto> patchDocument)
        {
            var item = await _itemService.GetByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            try
            {
                patchDocument.ApplyTo(item);
                await _itemService.UpdateAsync(item);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return UnprocessableEntity(e.Message);
            }

            return CreatedAtAction("GetItem", new { itemId = item.Id }, item);
        }
    }
}
