using Microsoft.AspNetCore.Mvc;
using TheBigStore.Repository.Extensions.Paging;
using TheBigStore.Service.DataTransferObjects;
using TheBigStore.Service.Extensions.Paging;
using TheBigStore.Service.Interfaces.OrderInterfaces;
using TheBigStore.Service.Services.OrderServices;

namespace TheBigStore.WebAPI.Controllers.ProductsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductsController : ControllerBase
    {
        private readonly IItemService _productServices;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IItemService productServices, ILogger<ProductsController> logger)
        {
            _productServices = productServices;
            _logger = logger;
        }

        /// <summary>
        /// Get List of all products in DB.
        /// </summary>
        /// <returns>Product Object</returns>
        [HttpGet]
        [Route("getpagnatedlist")]
        public async Task<IActionResult> GetPagnatedList(int page, int count)
        {
            var temp = await _productServices.GetPagnatedList(page, count);

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
            var temp = await _productServices.SearchProductByWord(searchString);

            if (temp != null)
            {
                return Ok(temp);
            }

            return NotFound();
        }
    }
}
