using System.Collections.ObjectModel;
using TheBigStore.Repository.Interfaces;
using TheBigStore.Service.Interfaces;

namespace TheBigStore.Service.Services
{
    public abstract class GenericService<Dto, IRepository, Entity>(MappingService mappingService, IRepository genericRepository) : IGenericService<Dto> where Dto : class where IRepository : IGenericRepository<Entity> where Entity : class
    {
        private readonly IRepository _genericRepository = genericRepository;
        private readonly MappingService _mappingService = mappingService;


        public async Task CreateAsync(Dto entity)
        {
            await _genericRepository.CreateAsync(_mappingService._mapper.Map<Entity>(entity));
        }

        public async Task DeleteAsync(Dto entity)
        {
            await _genericRepository.DeleteAsync(_mappingService._mapper.Map<Entity>(entity));
        }

        public async Task<ObservableCollection<Dto>> GetAllAsync()
        {
            return _mappingService._mapper.Map<ObservableCollection<Dto>>(await _genericRepository.GetAllAsync());
        }

        public async Task UpdateAsync(Dto entity)
        {
            await _genericRepository.UpdateAsync(_mappingService._mapper.Map<Entity>(entity));
        }


        public async Task<Dto?> GetById(int? id)
        {
            return _mappingService._mapper.Map<Dto?>(await _genericRepository.GetById(id));
        }

    }
}
