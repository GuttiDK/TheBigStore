using Microsoft.AspNetCore.Mvc;
using TheBigStore.Repository.Extensions.Paging;
using TheBigStore.Service.DataTransferObjects;
using TheBigStore.Service.Extensions.Paging;
using TheBigStore.Service.Interfaces.OrderInterfaces;

namespace TheBigStore.WebAPI.Controllers.ProductsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductsController : ControllerBase
    {
        private readonly IItemService _productServices;

        public ProductsController(IItemService productServices)
        {
            _productServices = productServices;
        }

        /// <summary>
        /// Get List of all products in DB.
        /// </summary>
        /// <returns>Product Object</returns>
        [HttpGet]
        public async Task<PageDto<ItemDto>> GetProducts(int page, int count)
        {
            return await _productServices.GetPagnatedList(page, count);
        }

        /// <summary>
        /// Get a List of products by search title.
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns>list of products</returns>
        [HttpGet]
        [Route("Search/{searchString}")]
        public async Task<List<ItemDto>> SearchProducts(string searchString) => await _productServices.SearchProductByWord(searchString);
    }
}
