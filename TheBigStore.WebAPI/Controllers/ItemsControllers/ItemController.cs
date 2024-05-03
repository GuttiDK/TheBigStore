using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TheBigStore.Service.DataTransferObjects;
using TheBigStore.Service.Interfaces.OrderInterfaces;
using TheBigStore.WebAPI.Extensions;
using TheBigStore.WebAPI.Models;

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


        // Check stock of an item with amount and id and returns bool
        [HttpGet]
        [Route("checkstock/{id:int}/{amount:int}")]
        public async Task<IActionResult> CheckStock(int id, int amount)
        {
            var context = await _itemService.CheckStock(id, amount);
            if (context != null)
            {
                return Ok(context);
            }
            return NotFound();
        }

        // Update stock of an item with amount and id
        [HttpPut]
        [Route("updatestock/{id:int}/{amount:int}")]
        public async Task<IActionResult> UpdateStock(int id, int amount)
        {
            try
            {
                await _itemService.UpdateStock(id, amount);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpGet("{id:int}", Name = "getitem")]
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
        public async Task<IActionResult> Create(ItemModel item)
        {
            ItemDto itemDto = new()
            {
                ItemName = item.ItemName,
                Description = item.Description,
                Price = item.Price,
                Stock = item.Stock,
                CategoryId = item.CategoryId,
            };

            try
            {
                itemDto = await _itemService.CreateAsync(itemDto);
                return CreatedAtAction("getitem", new { id = itemDto.Id }, itemDto);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpDelete]
        [Route("remove/{id:int}")]
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
                return CreatedAtAction("getitem", new { id = item.Id }, item);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpPatch]
        [Consumes("application/json-patch+json")]
        [Route("update/{id:int}")]
        public async Task<IActionResult> EditPartially(int id, [FromBody] JsonPatchDocument<ItemDto> patchDocument)
        {
            var item = await _itemService.GetByIdAsync(id);
            item.Category = null;
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

            return CreatedAtAction("getitem", new { id = item.Id }, item);
        }
    }
}
