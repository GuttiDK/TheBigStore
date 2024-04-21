using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TheBigStore.Service.DataTransferObjects;
using TheBigStore.Service.Interfaces.OrderInterfaces;

namespace TheBigStore.WebAPI.Controllers.ProductsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductController : ControllerBase
    {
        private readonly IItemService _itemService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IItemService itemService, ILogger<ProductController> logger)
        {
            _itemService = itemService;
            _logger = logger;
        }

        /// <summary>
        /// Get Product by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Product Object</returns>
        [HttpGet("{id:int}", Name = "GetProduct")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var temp = await _itemService.GetByIdAsync(id);

            if (temp != null)
            {
                return Ok(temp);
            }

            return NotFound();
        }


        /// <summary>
        /// Create a new product.
        /// </summary>
        /// <param name="item"></param>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(ItemDto item)
        {
            try
            {
                item = await _itemService.CreateAsync(item);
                return CreatedAtAction("GetProduct", new { Id = item.Id }, item);
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        /// <summary>
        /// Delete Product By ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Update product by ID.
        /// </summary>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> Edit(ItemDto item)
        {
            try
            {
                await _itemService.UpdateAsync(item);
                return CreatedAtAction("GetCategory", new { Id = item.Id }, item);
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

            return CreatedAtAction("GetCategory", new { CategoryId = item.Id }, item);
        }
    }
}
