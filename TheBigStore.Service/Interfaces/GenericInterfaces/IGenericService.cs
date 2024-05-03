using System.Collections.ObjectModel;
using TheBigStore.Service.Extensions.Paging;

namespace TheBigStore.Service.Interfaces.GenericInterfaces
{
    public interface IGenericService<Dto> where Dto : class
    {
        /// <summary>
        /// Create a new entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<Dto> CreateAsync(Dto entity);

        Task<List<Dto>> CreateListAsync(List<Dto> entityList);

        /// <summary>
        /// Deletes an entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<Dto> DeleteAsync(Dto entity);

        /// <summary>
        /// Updates an entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<Dto> UpdateAsync(Dto entity);

        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns></returns>
        Task<List<Dto>> GetAllAsync();

        /// <summary>
        /// Get an entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Dto> GetByIdAsync(int id);

        /// <summary>
        /// Gets a pagnated list of entities
        /// </summary>
        /// <param name="page"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        Task<PageDto<Dto>> GetPagnatedList(int page, int count);
    }
}
