using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using BNPLService.DTOs;

namespace BNPLService.Services
{
    public class UserClient : IUserClient
    {
        private readonly HttpClient _httpClient;

        public UserClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:5000"); 
        }

        public async Task<UserDTO?> GetUserByIdAsync(Guid userId)
        {
            var response = await _httpClient.GetAsync($"/api/users/{userId}");
            if (!response.IsSuccessStatusCode) return null;

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<UserDTO>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}