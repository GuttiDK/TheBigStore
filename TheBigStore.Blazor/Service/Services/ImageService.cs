using TheBigStore.Blazor.Models;
using TheBigStore.Blazor.Service.Intefaces;
using System.Net.Http.Json;

namespace TheBigStore.Blazor.Service.Services
{
    public class ImageService : IImageService
    {
        private readonly HttpClient _client;

        public ImageService(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<Image>> GetAllByItemId(int itemId)
        {
            var Request = $"/Image/GetImagesById/{itemId}";

            return await _client.GetFromJsonAsync<List<Image>>(Request);
        }
    }
}
