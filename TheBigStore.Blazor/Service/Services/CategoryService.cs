using TheBigStore.Blazor.Models;
using TheBigStore.Blazor.Service.Intefaces;
using System.Net.Http.Json;
using Newtonsoft.Json;

namespace TheBigStore.Blazor.Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _client;

        public CategoryService(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            var Request = "/api/Categories/get";
            return await _client.GetFromJsonAsync<List<Category>>(Request);
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            var Request = $"/Category/{id}";

            return await _client.GetFromJsonAsync<Category>(Request);
        }
    }
}
