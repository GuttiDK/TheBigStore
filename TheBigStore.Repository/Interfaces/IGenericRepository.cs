using System.Collections.ObjectModel;

namespace TheBigStore.Repository.Interfaces
{
    public interface IGenericRepository<E> where E : class
    {
        /// <summary>
        /// Create a new entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task CreateAsync(E entity);

        /// <summary>
        /// Deletes an entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task DeleteAsync(E entity);

        /// <summary>
        /// Updates an entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task UpdateAsync(E entity);

        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns></returns>
        Task<ObservableCollection<E>> GetAllAsync();

        /// <summary>
        /// Find an entity by id
        /// </summary>
        /// <returns></returns>
        Task<E?> GetById(int? id);
    }
}
