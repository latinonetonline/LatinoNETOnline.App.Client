using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

using LatinoNETOnline.App.Client.Core.Models;
using LatinoNETOnline.App.Client.Core.Models.Users;
using LatinoNETOnline.App.Client.Core.Services;

namespace LatinoNETOnline.App.Client.Services
{
    public class UserClientService : IUserClientService
    {
        private readonly HttpClient _httpClient;

        public UserClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Response> CreateUserAsync(User user)
        {
            var httpResponse = await _httpClient.PostAsJsonAsync("api/users", user);

            Response res = await httpResponse.Content.ReadFromJsonAsync<Response>();
            return res;
        }

        public async Task<Response> DeleteUserAsync(Guid userId)
        {
            var httpResponse = await _httpClient.DeleteAsync($"api/users/{userId}");
            Response res = await httpResponse.Content.ReadFromJsonAsync<Response>();
            return res;
        }

        public async Task<Response<User>> GetUserAsync(Guid userId)
        {
            return await _httpClient.GetFromJsonAsync<Response<User>>($"api/users/{userId}");
        }

        public async Task<ResponseEnumerable<User>> GetUsersAsync()
        {
            return await _httpClient.GetFromJsonAsync<ResponseEnumerable<User>>($"api/Users");
        }

        public async Task<Response> UpdateUserAsync(User user)
        {
            var httpResponse = await _httpClient.PutAsJsonAsync("api/users", user);

            Response res = await httpResponse.Content.ReadFromJsonAsync<Response>();
            return res;
        }
    }
}
