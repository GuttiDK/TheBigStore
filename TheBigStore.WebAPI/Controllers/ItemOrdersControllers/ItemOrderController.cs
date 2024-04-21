using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TheBigStore.Service.DataTransferObjects;
using TheBigStore.Service.Interfaces.OrderInterfaces;

namespace TheBigStore.WebAPI.Controllers.ItemOrdersControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ItemOrderController : ControllerBase
    {
        #region
        private readonly IItemOrderService _itemOrderService;
        private readonly ILogger<ItemOrderController> _logger;
        #endregion

        #region Constructor
        public ItemOrderController(IItemOrderService itemOrderService, ILogger<ItemOrderController> logger)
        {
            _itemOrderService = itemOrderService;
            _logger = logger;
        }
        #endregion


        [HttpGet("{id:int}", Name = "GetItemOrders")]
        public async Task<IActionResult> GetItemOrdersByOrderId(int id)
        {
            var temp = await _itemOrderService.GetAllByOrderId(id);

            if (temp != null)
            {
                return Ok(temp);
            }

            return NotFound();
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(List<ItemOrderDto> itemOrders)
        {
            try
            {
                await _itemOrderService.CreateListAsync(itemOrders);
                return CreatedAtAction("GetItemOrders", itemOrders);
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
            var itemOrder = await _itemOrderService.GetByIdAsync(id);

            if (itemOrder == null)
                return NotFound();

            try
            {
                await _itemOrderService.DeleteAsync(itemOrder);
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
        public async Task<IActionResult> Edit(ItemOrderDto itemOrder)
        {
            try
            {
                await _itemOrderService.UpdateAsync(itemOrder);
                return CreatedAtAction("GetItemOrder", new { ItemOrderId = itemOrder.Id }, itemOrder);
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpPatch("{id:int}")]
        [Route("update")]
        public async Task<IActionResult> EditPartially(int id, [FromBody] JsonPatchDocument<ItemOrderDto> patchDocument)
        {
            var itemOrder = await _itemOrderService.GetByIdAsync(id);
            if (itemOrder == null)
            {
                return NotFound();
            }

            try
            {
                patchDocument.ApplyTo(itemOrder);
                await _itemOrderService.UpdateAsync(itemOrder);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return UnprocessableEntity(e.Message);
            }

            return CreatedAtAction("GetItemOrder", new { ItemOrderId = itemOrder.Id }, itemOrder);
        }
    }
}
