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

        public ProductController(IItemService itemService)
        {
            _itemService = itemService;
        }

        /// <summary>
        /// Get Product by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Product Object</returns>
        [HttpGet()]
        [Route("Get/{id:int}")]
        public async Task<ActionResult<ItemDto>> GetProductById(int id) => await _itemService.GetById(id);

        /// <summary>
        /// Create a new product.
        /// </summary>
        /// <param name="newProduct"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Product
        ///     {
        ///         "masterKey": 0,
        ///         "title": "Test",
        ///         "description": "Test",
        ///         "price": 100,
        ///         "stock": 100,
        ///         "manufacture": "TestOfTest",
        ///         "imgPath": "string"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [HttpPost]
        [Route("Create")]
        public async Task<ItemDto> CreateProduct(ItemDto newProduct) => await _itemService.CreateAsync(newProduct);

        /// <summary>
        /// Update product by ID.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [HttpPut]
        [Route("Update")]
        public async Task UpdateProductById(ItemDto productsDTO) => await _itemService.UpdateAsync(productsDTO);

        /// <summary>
        /// Delete Product By ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Delete")]
        public async Task DeleteProductById(ItemDto id) => await _itemService.DeleteAsync(id);

    }
}
