using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TheBigStore.Repository.Models;
using TheBigStore.Service.DataTransferObjects;
using TheBigStore.Service.Interfaces.OrderInterfaces;
using TheBigStore.WebAPI.Extensions;
using TheBigStore.WebAPI.Models;

namespace TheBigStore.WebAPI.Controllers.OrdersControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class OrderController : ControllerBase
    {
        #region
        private readonly IOrderService _orderService;
        private readonly ILogger<OrderController> _logger;
        #endregion

        #region Constructor
        public OrderController(IOrderService orderService, ILogger<OrderController> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }
        #endregion





        [HttpGet("{id:int}", Name = "getorder")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var temp = await _orderService.GetByIdAsync(id);

            if (temp != null)
            {
                temp.Customer.Orders = null;
                return Ok(temp);
            }

            _logger.LogError("Order not found");
            return NotFound();
        }


        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(OrderModel order)
        {
            var orderDto = order.MapOrderToDto();

            try
            {
                orderDto = await _orderService.CreateAsync(orderDto);
                return CreatedAtAction("getorder", new { OrderId = orderDto.Id }, orderDto);
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
            var order = await _orderService.GetByIdAsync(id);

            if (order == null)
                return NotFound();

            try
            {
                await _orderService.DeleteAsync(order);
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
        public async Task<IActionResult> Edit(OrderDto order)
        {
            try
            {
                await _orderService.UpdateAsync(order);
                return CreatedAtAction("getorder", new { OrderId = order.Id }, order);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpPatch]
        [Route("update/{id:int}")]
        public async Task<IActionResult> EditPartially(int id, [FromBody] JsonPatchDocument<OrderDto> patchDocument)
        {
            var order = await _orderService.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            try
            {
                patchDocument.ApplyTo(order);
                await _orderService.UpdateAsync(order);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return UnprocessableEntity(e.Message);
            }

            return CreatedAtAction("getorder", new { OrderId = order.Id }, order);
        }
    }
}
