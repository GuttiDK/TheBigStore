using System.Collections.ObjectModel;
using TheBigStore.Repository.Models.Paging;

namespace TheBigStore.Repository.Interfaces.GenericInterfaces
{
    public interface IGenericRepository<E> where E : class
    {
        /// <summary>
        /// Create a new entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<E> CreateAsync(E entity);

        /// <summary>
        /// Adds a list of entities to the database
        /// </summary>
        /// <param name="entityList"></param>
        /// <returns></returns>
        Task<List<E>> CreateListAsync(List<E> entityList);

        /// <summary>
        /// Deletes an entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<E> DeleteAsync(E entity);

        /// <summary>
        /// Updates an entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<E> UpdateAsync(E entity);

        /// <summary>
        /// Updates a list of entities in the database
        /// </summary>
        /// <param name="entityList"></param>
        /// <returns></returns>
        Task<List<E>> UpdateListAsync(List<E> entityList);

        /// <summary>
        /// Gets an entities from the 
        /// </summary>
        /// <returns>A list of the data</returns>
        Task<List<E>> GetAllAsync();

        /// <summary>
        /// Find an entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Gets a entity of the id send with</returns>
        Task<E> GetByIdAsync(int id);

        /// <summary>
        /// Gets a pagnated list of entities
        /// </summary>
        /// <param name="page"></param>
        /// <param name="count"></param>
        /// <returns>Returns a page</returns>
        Task<Page<E>> GetPagnatedList(int page, int count);
    }
}
