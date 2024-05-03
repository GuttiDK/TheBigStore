using TheBigStore.Blazor.Models;

namespace TheBigStore.Blazor.Service.Interfaces
{
    public interface IImageService
    {
        /// <summary>
        /// Get all images by item id
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        Task <List<Image>> GetAllByItemId(int itemId);
    }
}
