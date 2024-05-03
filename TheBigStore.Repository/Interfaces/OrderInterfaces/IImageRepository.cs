using TheBigStore.Repository.Interfaces.GenericInterfaces;
using TheBigStore.Repository.Models;

namespace TheBigStore.Repository.Interfaces.OrderInterfaces
{
    public interface IImageRepository : IGenericRepository<Image>
    {

        Task<List<Image>> GetAllImagesByItemId(int itemId);
    }
}
