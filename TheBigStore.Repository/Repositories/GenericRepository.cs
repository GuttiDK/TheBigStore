using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using TheBigStore.Repository.Domain;
using TheBigStore.Repository.Interfaces;

namespace TheBigStore.Repository.Repositories
{
    public class GenericRepository<E>(TheBigStoreContext dbContext) : IGenericRepository<E> where E : class
    {
        private readonly TheBigStoreContext _dbContext = dbContext;

        public async Task CreateAsync(E entity)
        {
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(E entity)
        {
            _dbContext.Set<E>().Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(E entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ObservableCollection<E>> GetAllAsync()
        {
            ObservableCollection<E> temp = new(await _dbContext.Set<E>().AsNoTracking().ToListAsync());
            return temp;
        }
    }
}
