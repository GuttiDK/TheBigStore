using Microsoft.AspNetCore.Mvc;
using TheBigStore.Service.DataTransferObjects;
using TheBigStore.Service.Interfaces.OrderInterfaces;

namespace TheBigStore.WebAPI.Controllers.CategoriesControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        /// <summary>
        /// Get a list of all Categories.
        /// </summary>
        /// <returns>Categories list</returns>
        [HttpGet]
        public async Task<IEnumerable<CategoryDto>> Get()
        {
            return await _categoryService.GetAllAsync();
        }

        /// <summary>
        /// Get Pagnated List Categories.
        /// </summary>
        /// <returns>Categories Pagnated list</returns>
        [HttpGet(Name = "GetPagnatedList")]
        [Route("GetPagnatedList")]
        public async Task<IActionResult> GetPagnatedList(int page, int count)
        {
            var temp = await _categoryService.GetPagnatedList(page, count);

            if (temp != null)
            {
                return Ok(temp);
            }

            return BadRequest();
        }
    }
}
