using TheBigStore.Service.DataTransferObjects;
using TheBigStore.Service.Interfaces.GenericInterfaces;

namespace TheBigStore.Service.Interfaces.OrderInterfaces
{
    public interface IImageService : IGenericService<ImageDto>
    {
        Task<IEnumerable<ImageDto>> GetAllImagesByItemId(int itemId);
    }
}
