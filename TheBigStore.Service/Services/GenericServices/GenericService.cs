using System.Collections.ObjectModel;
using TheBigStore.Repository.Interfaces.GenericInterfaces;
using TheBigStore.Service.Extensions.Paging;
using TheBigStore.Service.Interfaces.GenericInterfaces;
using TheBigStore.Service.Services.MappingServices;

namespace TheBigStore.Service.Services.GenericServices
{
    public abstract class GenericService<Dto, IRepository, Entity>(MappingService mappingService, IRepository genericRepository) : IGenericService<Dto> where Dto : class where IRepository : IGenericRepository<Entity> where Entity : class
    {
        private readonly IRepository _genericRepository = genericRepository;
        private readonly MappingService _mappingService = mappingService;


        public async Task<Dto> CreateAsync(Dto entity)
        {
            await _genericRepository.CreateAsync(_mappingService._mapper.Map<Entity>(entity));
            return entity;
        }

        public async Task<Dto> DeleteAsync(Dto entity)
        {
            await _genericRepository.DeleteAsync(_mappingService._mapper.Map<Entity>(entity));
            return entity;
        }

        public async Task<ObservableCollection<Dto>> GetAllAsync()
        {
            return _mappingService._mapper.Map<ObservableCollection<Dto>>(await _genericRepository.GetAllAsync());
        }

        public async Task<Dto> UpdateAsync(Dto entity)
        {
            await _genericRepository.UpdateAsync(_mappingService._mapper.Map<Entity>(entity));
            return entity;
        }

        public async Task<Dto> GetById(int id)
        {
            return _mappingService._mapper.Map<Dto>(await _genericRepository.GetById(id));
        }


        // GetPagnatedList should be implemented and it should return a pagnated list of entities
        public async Task<PageDto<Dto>> GetPagnatedList(int page, int count)
        {
            var pageDto = new PageDto<Dto>();
            var pageEntity = await _genericRepository.GetPagnatedList(page, count);
            pageDto.Total = pageEntity.Total;
            pageDto.CurrentPage = pageEntity.CurrentPage;
            pageDto.PageSize = pageEntity.PageSize;
            pageDto.Items = _mappingService._mapper.Map<List<Dto>>(pageEntity.Items);
            return pageDto;
        }

    }
}
