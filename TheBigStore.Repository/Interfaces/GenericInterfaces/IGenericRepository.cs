using System.Collections.ObjectModel;
using TheBigStore.Repository.Extensions.Paging;

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
        /// Get all entities
        /// </summary>
        /// <returns>A list of the data</returns>
        Task<ObservableCollection<E>> GetAllAsync();

        /// <summary>
        /// Find an entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Gets a entity of the id send with</returns>
        Task<E> GetById(int id);

        /// <summary>
        /// Gets a pagnated list of entities
        /// </summary>
        /// <param name="page"></param>
        /// <param name="count"></param>
        /// <returns>Returns a page</returns>
        Task<Page<E>> GetPagnatedList(int page, int count);
    }
}
