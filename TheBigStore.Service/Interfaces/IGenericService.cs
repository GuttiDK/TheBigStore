using System.Collections.ObjectModel;

namespace TheBigStore.Service.Interfaces
{
    public interface IGenericService<Dto> where Dto : class
    {
        /// <summary>
        /// Create a new entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task CreateAsync(Dto entity);

        /// <summary>
        /// Deletes an entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task DeleteAsync(Dto entity);

        /// <summary>
        /// Updates an entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task UpdateAsync(Dto entity);

        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns></returns>
        Task<ObservableCollection<Dto>> GetAllAsync();
    }
}
