using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using TheBigStore.Repository.Domain;
using TheBigStore.Repository.Extensions;
using TheBigStore.Repository.Interfaces.GenericInterfaces;
using TheBigStore.Repository.Models;
using TheBigStore.Repository.Models.Paging;

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

        public async Task<List<E>> CreateListAsync(List<E> entityList)
        {
            _dbContext.AddRange(entityList);
            await _dbContext.SaveChangesAsync();
            return entityList;
        }

        public async Task<E> UpdateAsync(E entity)
        {
            _dbContext.Set<E>().Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<E>> UpdateListAsync(List<E> entityList)
        {
            _dbContext.Set<E>().AttachRange(entityList);
            foreach (E entity in entityList)
            {
                _dbContext.Entry(entity).State = EntityState.Modified;
            }
            await _dbContext.SaveChangesAsync();
            return entityList;
        }

        public async Task<E> DeleteAsync(E entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<E>> GetAllAsync()
        {
            List<E> temp = new(await _dbContext.Set<E>().AsNoTracking().ToListAsync());
            return temp;
        }

        public async Task<E> GetByIdAsync(int id)
        {
            E entity = await _dbContext.Set<E>().FindAsync(id);
            _dbContext.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public async Task<Page<E>> GetPagnatedList(PageOptions options)
        {
            var query = _dbContext.Set<E>().AsNoTracking();
            Page<E> pageResult = new()
            { 
                Total = query.Count(), 
                Items = await query.Page(options.CurrentPage, options.PageSize).ToListAsync(), 
                CurrentPage = options.CurrentPage, 
                PageSize = options.PageSize 
            };
            return pageResult;
        }

    }
}
