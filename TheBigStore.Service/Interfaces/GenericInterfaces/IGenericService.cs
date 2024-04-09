using System.Collections.ObjectModel;

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
        Task<ObservableCollection<Dto>> GetAllAsync();

        /// <summary>
        /// Get an entity by id
        /// </summary>
        /// <returns></returns>
        Task<Dto> GetById(int id);
    }
}
