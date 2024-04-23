using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TheBigStore.Service.DataTransferObjects;
using TheBigStore.Service.Interfaces.OrderInterfaces;
using TheBigStore.WebAPI.Extensions;
using TheBigStore.WebAPI.Models;

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


        [HttpGet("{id:int}", Name = "getcategory")]
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
        public async Task<IActionResult> Create(CategoryModel category)
        {
            var categoryDto = category.MapCategoryToDto();

            try
            {
                categoryDto = await _categoryService.CreateAsync(categoryDto);
                return CreatedAtAction("getcategory", new { Id = categoryDto.Id }, categoryDto);
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
            var temp = await _categoryService.GetByIdAsync(id);

            if (temp == null)
                return NotFound();

            try
            {
                await _categoryService.DeleteAsync(temp);
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
                return CreatedAtAction("getcategory", new { Id = category.Id }, category);
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpPatch]
        [Route("update/{id:int}")]
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

            return CreatedAtAction("getcategory", new { Id = category.Id }, category);
        }
    }
}
