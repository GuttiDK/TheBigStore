using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TheBigStore.Service.DataTransferObjects;
using TheBigStore.Service.Interfaces.OrderInterfaces;
using TheBigStore.WebAPI.Extensions;
using TheBigStore.WebAPI.Models;

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


        [HttpGet("{id:int}", Name = "getitemorders")]
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
        public async Task<IActionResult> Create(List<ItemOrderModel> itemOrders)
        {
            var itemOrdersDto = itemOrders.MapItemOrderToDto();

            try
            {
                await _itemOrderService.CreateListAsync(itemOrdersDto);
                return CreatedAtAction("getitemorders", itemOrdersDto);
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpDelete]
        [Route("remove/{id:int}")]
        public async Task<IActionResult> Remove(int id)
        {
            var temp = await _itemOrderService.GetByIdAsync(id);

            if (temp == null)
                return NotFound();

            try
            {
                await _itemOrderService.DeleteAsync(temp);
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
                return CreatedAtAction("getitemorder", new { Id = itemOrder.Id }, itemOrder);
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpPatch]
        [Route("update/{id:int}")]
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

            return CreatedAtAction("getitemorder", new { Id = itemOrder.Id }, itemOrder);
        }
    }
}
