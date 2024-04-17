using TheBigStore.Repository.Interfaces.OrderInterfaces;
using TheBigStore.Repository.Models;
using TheBigStore.Service.DataTransferObjects;
using TheBigStore.Service.Interfaces.OrderInterfaces;
using TheBigStore.Service.Services.GenericServices;
using TheBigStore.Service.Services.MappingServices;

namespace TheBigStore.Service.Services.OrderServices
{
    public class CategoryService : GenericService<CategoryDto, ICategoryRepository, Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly MappingService _mappingService;
        public CategoryService(MappingService mappingService, ICategoryRepository categoryRepository) : base(mappingService, categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _mappingService = mappingService;
        }
    }
}
