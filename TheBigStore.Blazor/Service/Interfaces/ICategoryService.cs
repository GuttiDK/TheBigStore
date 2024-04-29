using TheBigStore.Blazor.Models;

namespace TheBigStore.Blazor.Service.Intefaces
{
    public interface ICategoryService
    {

        /// <summary>
        /// Get all categories
        /// </summary>
        /// <returns></returns>
        public Task<List<Category>> GetAllCategoriesAsync();

        /// <summary>
        /// Get category by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Category> GetByIdAsync(int id);
    }
}
