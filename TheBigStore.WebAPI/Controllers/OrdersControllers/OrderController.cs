using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TheBigStore.Service.DataTransferObjects;
using TheBigStore.Service.Interfaces.OrderInterfaces;

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





        [HttpGet("{id:int}", Name = "GetOrder")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var temp = await _orderService.GetByIdAsync(id);

            if (temp != null)
            {
                temp.Customer.Orders = null;
                return Ok(temp);
            }

            return NotFound();
        }


        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(OrderDto order)
        {
            try
            {
                order = await _orderService.CreateAsync(order);
                return CreatedAtAction("GetOrder", new { OrderId = order.Id }, order);
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
                return CreatedAtAction("GetOrder", new { OrderId = order.Id }, order);
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpPatch("{id:int}")]
        [Route("update")]
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

            return CreatedAtAction("GetOrder", new { OrderId = order.Id }, order);
        }
    }
}
