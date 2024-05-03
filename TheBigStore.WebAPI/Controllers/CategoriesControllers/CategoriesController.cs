using Microsoft.AspNetCore.Mvc;
using TheBigStore.Repository.Extensions;
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
        [Route("get")]
        public async Task<IEnumerable<CategoryDto>> Get()
        {
            return await _categoryService.GetAllAsync();
        }

        /// <summary>
        /// Get Pagnated List Categories.
        /// </summary>
        /// <returns>Categories Pagnated list</returns>
        [HttpGet]
        [Route("getpagnatedlist")]
        public async Task<IActionResult> GetPagnatedList(int page, int count)
        {
            PageOptions options = new()
            {
                CurrentPage = page,
                PageSize = count
            };
            var temp = await _categoryService.GetPagnatedList(options);

            if (temp != null)
            {
                return Ok(temp);
            }

            return BadRequest();
        }
    }
}
