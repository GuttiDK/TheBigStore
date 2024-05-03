using TheBigStore.Repository.Interfaces.OrderInterfaces;
using TheBigStore.Repository.Models;
using TheBigStore.Repository.Repositories.OrderRepositories;
using TheBigStore.Service.DataTransferObjects;
using TheBigStore.Service.Interfaces.OrderInterfaces;
using TheBigStore.Service.Services.GenericServices;
using TheBigStore.Service.Services.MappingServices;

namespace TheBigStore.Service.Services.OrderServices
{
    public class ImageService : GenericService<ImageDto, IImageRepository, Image>, IImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly MappingService _mappingService;

        public ImageService(MappingService mappingService, IImageRepository imageRepository) : base(mappingService, imageRepository)
        {
            _imageRepository = imageRepository;
            _mappingService = mappingService;
        }

        public async Task<IEnumerable<ImageDto>> GetAllImagesByItemId(int itemId)
        {
            var temp = _mappingService._mapper.Map<IEnumerable<ImageDto>>(await _imageRepository.GetAllImagesByItemId(itemId));
            return temp;
        }
    }
}
