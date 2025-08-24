using BNPLService.Models;

namespace BNPLService.Services
{
    public class BNPLManager
    {   
        private readonly HttpClient _httpClient;
        public BNPLManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        private readonly List<BNPLApp> _applications = new();
        public async Task<BNPLApp> CreateApplication(Guid userId, Guid productId)
        {
            //simulate call to UserService
                        var userResponse = await _httpClient.GetAsync($"http://localhost:5000/api/users/{userId}");
            if (!userResponse.IsSuccessStatusCode)
                {
                throw new Exception("User not found");
            }

            //simulate call to ProductService
            var productResponse = await _httpClient.GetAsync($"http://localhost:5000/api/products/{productId}");
            if (!productResponse.IsSuccessStatusCode)
            {
                throw new Exception("Product not found");
            }
            var application = new BNPLApp
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                ProductId = productId,
                CreatedAt = DateTime.UtcNow,
                Status = "Pending"
            };
            _applications.Add(application);
            return application;
        }
        public IEnumerable<BNPLApp> GetAllApplications()
        {
            return _applications;
        }
        public BNPLApp? GetApplicationById(Guid id)
        {
            return _applications.FirstOrDefault(app => app.Id == id);
        }

    }

}
