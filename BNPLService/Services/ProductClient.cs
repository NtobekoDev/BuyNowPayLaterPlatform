using System;
using System.Text.Json;
using System.Net.Http;
using System.Threading.Tasks;
using BNPLService.DTOs;

namespace BNPLService.Services
{


	public class ProductClient : IProductClient
	{
		private readonly HttpClient _httpClient;
		public ProductClient(HttpClient httpClient)
		{
			_httpClient = httpClient;
			_httpClient.BaseAddress = new Uri("http://localhost:5000");
		}
		public async Task<ProductDTO?> GetProductByIdAsync(Guid productId)
		{
			var response = await _httpClient.GetAsync($"api/products/{productId}");
			if (!response.IsSuccessStatusCode)
			{
				return null;
			}
			var content = await response.Content.ReadAsStringAsync();
			return JsonSerializer.Deserialize<ProductDTO>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

		}
	}
}