using Microsoft.AspNetCore.Mvc;
using TheBigStore.Repository.Models;
using TheBigStore.Service.DataTransferObjects;
using TheBigStore.Service.Interfaces.OrderInterfaces;

namespace TheBigStore.WebAPI.Controllers.CategoriesControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        /// <summary>
        /// Get Category by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Category Object</returns>
        [HttpGet("{id}")]
        public async Task<CategoryDto> GetCategoryById(int id)
        {
            return await _categoryService.GetById(id);
        }

        /// <summary>
        /// Create new Category.
        /// </summary>
        /// <param name="category"></param>
        [HttpPost]
        [Route("Create")]
        public async Task AddCategoryAsync(CategoryDto category)
        {
            await _categoryService.CreateAsync(category);
        }
    }
}
