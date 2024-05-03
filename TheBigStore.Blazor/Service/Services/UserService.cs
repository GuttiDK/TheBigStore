using System.Net.Http.Json;
using TheBigStore.Blazor.Models;
using TheBigStore.Blazor.Service.Interfaces;

namespace TheBigStore.Blazor.Service.Services
{
    public class UserService : IUserService
    {

        private readonly HttpClient _client;

        public UserService(HttpClient client)
        {
            _client = client;
        }

        public async Task<User> CreateUser(User user)
        {
            var response = await _client.PostAsJsonAsync("/api/user/create", user);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<User>();
        }
    }
}
