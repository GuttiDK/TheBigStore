using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TheBigStore.Service.DataTransferObjects;
using TheBigStore.Service.Interfaces.OrderInterfaces;

namespace TheBigStore.WebAPI.Controllers.CategoriesControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CategoryController : ControllerBase
    {
        #region
        private readonly ICategoryService _categoryService;
        private readonly ILogger<CategoryController> _logger;
        #endregion

        #region Constructor
        public CategoryController(ICategoryService CategoryService, ILogger<CategoryController> logger)
        {
            _categoryService = CategoryService;
            _logger = logger;
        }
        #endregion


        [HttpGet("{id:int}", Name = "GetCategory")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var temp = await _categoryService.GetByIdAsync(id);

            if (temp != null)
            {
                return Ok(temp);
            }

            return NotFound();
        }


        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(CategoryDto Category)
        {
            try
            {
                Category = await _categoryService.CreateAsync(Category);
                return CreatedAtAction("GetCategory", new { CategoryId = Category.Id }, Category);
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
            var Category = await _categoryService.GetByIdAsync(id);

            if (Category == null)
                return NotFound();

            try
            {
                await _categoryService.DeleteAsync(Category);
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
        public async Task<IActionResult> Edit(CategoryDto category)
        {
            try
            {
                await _categoryService.UpdateAsync(category);
                return CreatedAtAction("GetCategory", new { CategoryId = category.Id }, category);
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpPatch("{id:int}")]
        [Route("update")]
        public async Task<IActionResult> EditPartially(int id, [FromBody] JsonPatchDocument<CategoryDto> patchDocument)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            try
            {
                patchDocument.ApplyTo(category);
                await _categoryService.UpdateAsync(category);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return UnprocessableEntity(e.Message);
            }

            return CreatedAtAction("GetCategory", new { CategoryId = category.Id }, category);
        }
    }
}
