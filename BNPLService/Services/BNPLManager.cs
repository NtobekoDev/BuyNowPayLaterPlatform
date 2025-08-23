using BNPLService.Models;

namespace BNPLService.Services
{
    public class BNPLManager
    {
        private readonly List<BNPLApp> _applications = new();
        public BNPLApp CreateApplication(Guid userId, Guid productId)
        {
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
