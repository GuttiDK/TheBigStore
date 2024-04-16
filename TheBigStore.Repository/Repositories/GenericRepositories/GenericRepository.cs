using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using TheBigStore.Repository.Domain;
using TheBigStore.Repository.Extensions;
using TheBigStore.Repository.Extensions.Paging;
using TheBigStore.Repository.Interfaces.GenericInterfaces;
using TheBigStore.Repository.Models;

namespace TheBigStore.Repository.Repositories.GenericRepositories
{
    public class GenericRepository<E> : IGenericRepository<E> where E : class
    {
        private readonly TheBigStoreContext _dbContext;

        public GenericRepository(TheBigStoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<E> CreateAsync(E entity)
        {
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<E> UpdateAsync(E entity)
        {
            _dbContext.Set<E>().Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<E> DeleteAsync(E entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<ObservableCollection<E>> GetAllAsync()
        {
            ObservableCollection<E> temp = new(await _dbContext.Set<E>().AsNoTracking().ToListAsync());
            return temp;
        }

        public async Task<E> GetById(int id)
        {
            E? e = await _dbContext.Set<E>().FindAsync(id);
            _dbContext.Entry(e).State = EntityState.Detached;
            return e ?? throw new Exception("Entity not found");
        }

        public async Task<Page<E>> GetPagnatedList(int page, int count)
        {
            var query = _dbContext.Set<E>().AsNoTracking();
            return new Page<E> { Total = query.Count(), Items = await query.Page(page, count).ToListAsync(), CurrentPage = page, PageSize = count };
        }

    }
}
