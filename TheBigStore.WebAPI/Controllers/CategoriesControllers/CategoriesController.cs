using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using TheBigStore.Repository.Models;
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
        public async Task<ObservableCollection<CategoryDto>> GetCategories()
        {
            return await _categoryService.GetAllAsync();
        }
    }
}
